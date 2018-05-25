using DemoMVVMAprendices.Model;
using DemoMVVMAprendices.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoMVVMAprendices.ViewModel
{
   public class AprendizPageViewModel : Notificable
    {
        private ObservableCollection<Aprendiz> aprendices;
       
        public ObservableCollection<Aprendiz> Aprendices
        {
            get {
                return aprendices;
            }
            set
            {
                if (aprendices == value)
                {
                   return;
                }
                aprendices = value;
                OnPropertyChanged();
            }
        }
        private bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                OnPropertyChanged();
            }
        }
        public Command CargarAprendizCommand { get; set;}

        public AprendizPageViewModel()
        {
            Aprendices = new ObservableCollection<Aprendiz>();
            CargarAprendizCommand = new Command((obj) => CargarAprendices());
        }
        private async void CargarAprendices()
        {
            if (!IsEnabled)
            {
                IsEnabled = true;
                await Task.Delay(3000);
                Data listAprendices = CaracterizacionAprendices.CargarAprendices();
                Aprendices = listAprendices.Aprendices;
                IsEnabled = false;
            }
        }
    }
}
