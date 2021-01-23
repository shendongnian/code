    ObservableCollection<Item> _selectedItems;
    // used to handle multi selection, the easiest is to set it from View in SelectionChanged event
    public ObservableCollection<Item> SelectedItems
    {
        get { return _selectedItems; }
        set
        {
            _selectedItems = value;
            OnPropertyChanged();
            // this will trigger View updating value from getter
            OnPropertyChanged(nameof(SomeProperty));
        }
    }
    // this will be one of your properties to edit, you'll have to do this for each property you want to edit
    public double SomeProperty
    {
        get { return SelectedItems.Average(); } // as example
        set
        {
            foreach(var item in SelectedItems)
                item.SomeProperty = value;
        }
    }
