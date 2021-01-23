    ObservableCollectionProp.CollectionChanged += CollectionChangedHandler;
    
    private void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
        CollectionCount = ObservableCollectionProp.Count;
    }
