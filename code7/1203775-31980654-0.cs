    collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(collection_CollectionChanged);
    // ...
    // and add the method
    void collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        {
            foreach (var it in e.OldItems) {
                var custclass = it as CustomClassName;
                if (custclass != null) custclass.SomeEvent -= OnSomeEvent;
            }
        }
    }
