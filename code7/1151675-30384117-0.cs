    public class Field : INotifyPropertyChanged
    {
        private bool _available;
        private ReservationDTO _reservation;
        public string Statusz
        {
            get
            {
                return _reservation.Statusz;
            }
            set
            {
                if (_reservation.Statusz != value)
                {
                    _reservation.Statusz = value;
                    OnPropertyChanged("Available");
                }
            }
        }
        public DelegateCommand FieldChangeCommand { get; set; }
        public bool Available
        {
            get
            {
                return _available;
            }
            set
            {
                if (_available != value)
                {
                    _available = value;
                    OnPropertyChanged("Available");
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var localHandler = this.PropertyChanged;
            if (localHandler != null)
            {
                localHandler(this, new PropertyChangedEventArgs(propertyName));       
            }
        }
    }
