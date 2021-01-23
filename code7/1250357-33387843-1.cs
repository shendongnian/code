        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set 
            {
                _items = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Items"));
            }
        }
