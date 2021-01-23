        private ObservableCollection<string> _locations;
        public ObservableCollection<string> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Locations"));
            }
        }
