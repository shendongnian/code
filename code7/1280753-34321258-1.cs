    class ViewModel : INotifyPropertyChanged
    {
        private string car;
        public ViewModel()
        {
            this.Car = "VW";
        }
        public string Car
        {
            get
            {
                return this.car;
            }
            set
            {
                if (this.car != value)
                {
                    this.car = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
