    public ObservableCollection<CustomItem> CustomItems
        {
            get { return _customItems; }
            private set
            {
                if (Equals(value, _customItems)) return;
                _customItems= value;
                RaisePropertyChanged("CustomItems");
            }
        }
