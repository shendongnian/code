    public string Selection
    {
        get
        {
            return (string)base.GetValue(SelectionProperty);
        }
        set
        {
            base.SetValue(SelectionProperty, value);
            if(value != SelectedText)
                SelectedText = value;
        }
    }
