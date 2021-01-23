    public ObservableCollection<YourClass> Items
    {
        get { return items; }
        set { items = value; NotifyPropertyChanged("Items"); }
    }
