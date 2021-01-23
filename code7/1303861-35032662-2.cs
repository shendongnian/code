    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Item removed = e.RemovedItems.FirstOrDefault() as Item;
        if (removed != null)
        {
            removed.IsReadOnly = true;
        }
        Item added = e.AddedItems.FirstOrDefault() as Item;
        if (added != null)
        {
            added.IsReadOnly = false;
        }
    }
