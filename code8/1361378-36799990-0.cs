    public class DeviceOptionViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _currentDevice;
        public String CurrentDevice {
            get { return _currentDevice; }
            set { 
                _currentDevice = value; 
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(nameof(CurrentDevice));
            }
        }
        //  Parent event assigns this to his own availableDevices
        //  when he creates this.
        public IEnumerable AvailableDevices { get; set; }
    }
