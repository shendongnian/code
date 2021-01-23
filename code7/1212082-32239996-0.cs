    myFoos.CollectionChanged += (sender, e) =>
    {
        if (e.Action == NotifyCollectionChangedAction.Remove ||
            e.Action == NotifyCollectionChangedAction.Replace)
        {
            foreach (Foo foo in e.OldItems)
            {
                foo.CancelThread(); // or whatever
            }
        }
    };
