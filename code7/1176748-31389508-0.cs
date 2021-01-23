    public void SetFilter(Predicate<object> filter)
    {
        if (Items.CurrentItem != null && !filter(Items.CurrentItem))
        {
            Item = null;
            OnPropertyChanged("Item");
        }
        Items.Filter = filter;
        if (Items.CurrentItem == null && !Items.IsEmpty)
            Items.MoveCurrentToFirst();
    }
