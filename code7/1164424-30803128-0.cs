    private IList mItemsAsList;
    private INotifyCollectionChanged mItemsAsObservable;
    // Call when the value of ItemsProperty changes
    private void OnItemsChanged(IEnumerable newValue)
    {
        if (mItemsAsObservable != null)
        {
            mItemsAsObservable.CollectionChanged -= Items_CollectionChanged;
        }
        mItemsAsList = newValue as IList;
        mItemsAsObservable = newValue as INotifyCollectionChanged;
        if (mItemsAsObservable != null)
        {
            mItemsAsObservable.CollectionChanged += Items_CollectionChanged;
        }
    }
    private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Do stuff in response to collection being changed
    }
