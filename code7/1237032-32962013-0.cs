    private DataModel()
    {
        Projects.CollectionChanged += Projects_CollectionChanged;
    }
    private void Projects_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            // An item was added...
        }
    }
