    private void ProxyListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (var newItem in e.NewItems)
            {
                QuickAccessToolBar.Items.Add(newItem);
            }
        }
    
        if (e.OldItems != null)
        {
            foreach (var oldItem in e.OldItems)
            {
                QuickAccessToolBar.Items.Remove(oldItem);
            }
        }
    }
    
    private void QuickAccessToolBar_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        ((INotifyCollectionChanged)ProxyListBox.Items).CollectionChanged += ProxyListBox_CollectionChanged;
    }
