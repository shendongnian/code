    private ObservableCollection<KeyValuePair<string,string>> _items = new ObservableCollection<KeyValuePair<string, string>>();
        public ObservableCollection<KeyValuePair<string,string>> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items == value)
                {
                    return;
                }
                _items = value;                
            }
        }
