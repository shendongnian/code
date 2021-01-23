    public ObservableCollection(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException("collection");
 
        CopyFrom(collection);
    }
