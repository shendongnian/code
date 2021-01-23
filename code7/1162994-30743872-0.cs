    static void coll_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        List<string> items = new List<string>();
    
        //added items
        if (e.NewItems != null)
            items.AddRange(e.NewItems.OfType<string>());
    
        ///old items
        if (e.OldItems != null)
            items.AddRange(e.OldItems.OfType<string>());
    
        Console.WriteLine(string.Join(", ", items));
    }
