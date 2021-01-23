    private string _itemTitle
    public string ItemTitle
        {
            get
            {
                return _itemTitle;
            }
            set
            {
                _itemTitle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ItemTitle"));
            }
