    public Dictionary<string, object> SelectedItems
    {
        get { return selectedItems; }
        set
        {
            if (selectedItems == value) <----------- here breakpoint
                return;
            selectedItems = value;
            NotifyOfPropertyChange(() => SelectedItems);
        }
    }
