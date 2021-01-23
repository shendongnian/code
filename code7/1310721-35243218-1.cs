    private static void Source_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        NexusEditor c = (NexusEditor)d;
    
        if (e.OldValue != null)
        {
            var notifyCollectionChanged = e.OldValue as INotifyCollectionChanged;
            if (notifyCollectionChanged != null)
            {
                notifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(c.Source_CollectionChanged);
            }
        }
    
        if (e.NewValue != null)
        {
            var notifyCollectionChanged = e.NewValue as INotifyCollectionChanged;
            if (notifyCollectionChanged != null)
            {
                notifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(c.Source_CollectionChanged);
            }
        }
    
        UpdateItems(c);
    }
