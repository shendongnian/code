    // subscribe
    UnfilteredList += OnCollectionChanged;
    
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if ((e.NewItems != null) || (e.OldItems != null))
        {
            UpdateList();
        }
    }
