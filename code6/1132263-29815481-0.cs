    private object _mySelectedItem;
        public object MySelectedItem
        {
            get { return _mySelectedItem; }
            set 
            {
                if (_mySelectedItem != value && value != null)
                {
                    _mySelectedItem = value;
                    OnPropertyChanged("MySelectedItem");
                }
            }
        }
