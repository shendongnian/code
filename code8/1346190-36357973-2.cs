    public DataRow SelectedItem
    {
        get
        {
            return _MainModel.SelectedItem;
        }
        set
        {
            _MainModel.SelectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }
