    public Dictionary<string, object> SelectedItems
    {
        get { return (Dictionary<string, object>)GetValue(SelectedItemsProperty);}
        set { SetValue(SelectedItemsProperty, value); NotifyOfPropertyChange(() => Items);}
    }
