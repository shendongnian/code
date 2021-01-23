    using System.Collections.ObjectModel;
    public class Vm : ViewModelBase
    {    
        private ObservableCollection<Devices> devices;
        public ObservableCollection<Devices> Devices
        {
            get
            {
                return devices;
            }
            set
            {
                devices = value;
                NotifyPropertyChanged("Devices");
            }
        }
        public Vm()
        {
            ...
        }
    }
