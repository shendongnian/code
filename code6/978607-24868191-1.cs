    public ComboValue SelectedItem
    {
        get 
        { 
            return _selectedItem;
        }
        set
        {
            if (_selectedItem != value)
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
    }
