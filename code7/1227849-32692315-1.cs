    public bool HasItems
    {
        get
        {
            return Items != null && Items.Count() > 0;
        }
    }
    public IEnumerable Items
    {
        get
        {
            // ...
        }
        set
        {
            // ...
            RaisePropertyChanged("HasItems");
        }
    }
