     private ObservableCollection<Property> _itemProperties;
        public ObservableCollection<Property> ItemProperties
        {
            get { return _itemProperties; }
            set
            {
                _itemProperties= value;
               RaisePropertyChanged(() => ItemProperties);
            }
        }
