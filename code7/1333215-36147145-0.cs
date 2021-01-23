    protected override void OnBindingContextChanged(EventArgs e)
    {
        foreach (Binding item in DataBindings)
        {
            if (item.PropertyName == "SomeProperty")
                item.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }
        base.OnBindingContextChanged(e);
    }
