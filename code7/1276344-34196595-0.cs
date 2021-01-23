    SomeType _selectedItem;
    public SomeType SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            // ... put your logic when user change selection here
        }
    }
    // use this to change selection from viewmodel
    public SomeType SelectedItemSet
    {
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            // ... put your logic when selected item is set by viewmodel here
        }
    }
