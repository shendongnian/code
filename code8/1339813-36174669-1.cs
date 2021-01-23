    ItemVM _selectedItem;
    public ItemVM SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            // trigger update in the view
            OnPropertyChanged(nameof(SomeRelatedProperty));
        }
    }
    // bind TextBlock.Text to that property
    public string SomeRelatedProperty
    {
        get
        {
            // some logic based on selected item
            if(SelectedItem.SomeProperty == SomeValue)
                return "a";
            ...
            return "b";
        }
    }
