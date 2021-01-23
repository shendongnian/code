    private object _selectedItem;
    public object SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            PropertyChanged(this,new PropertyChangedEventArgs("SelectedItem"));
        }
    }
