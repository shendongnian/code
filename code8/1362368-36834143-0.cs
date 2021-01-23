    void myCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null)
        {
             foreach (var removedItem in e.OldItems)
             {
             }
        }
    }
