    // in constructor or where your class gets information about the list
    Settings.PushCol.CollectionChanged += OnCollectionChanged;
    public ObservableCollection<Push> Pushes
    {
        get { return Settings.PushCol; }
    }
    private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
            {
                // do sorting here
            }
        }
    }
