    class ViewModel : INotifyPropertyChanged
    {
        private string car;
        public ViewModel()
        {
            this.Car = "VW";
            this.Cars = new ObservableCollection<string>() { "Mazda", "VW", "Audi" };
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
        public ObservableCollection<string> Cars { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
