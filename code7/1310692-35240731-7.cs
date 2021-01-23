     private ObservableCollection<string> _cboxItemsCollection = new ObservableCollection<string>()
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
        };        
        public ObservableCollection<string> CboxItems
        {
            get
            {
                return _cboxItemsCollection;
            }
            set
            {
                if (_cboxItemsCollection == value)
                {
                    return;
                }
                _cboxItemsCollection = value;
                OnPropertyChanged();
            }
        }
