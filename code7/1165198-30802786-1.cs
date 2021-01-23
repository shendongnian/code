        private ObservableCollection<Employee> _items = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> items
        {
            get { return _items; }
            set
            {
                _items = value;
                PropertyChanged(this, new PropertyChangedEventArgs("items"));
            }
        }
