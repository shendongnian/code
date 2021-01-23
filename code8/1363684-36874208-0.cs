    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _activeDuty = false;
        public bool activeDuty {
            get { return _activeDuty; }
            set {
                _activeDuty = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(nameof(activeDuty)));
            }
        }
        //  Name implemented similarly -- either that, or give it a protected 
        //  setter and initialize it in the constructor, to prevent accidents.
    }
