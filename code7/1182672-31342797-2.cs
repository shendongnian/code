    /// <summary>
    /// Called by base class Collection&lt;T&gt; when an item is set in list;
    /// raises a CollectionChanged event to any listeners.
    /// </summary>
    protected override void SetItem(int index, T item)
    {
        CheckReentrancy();
        T originalItem = this[index];
        base.SetItem(index, item);
 
        OnPropertyChanged(IndexerName);
        OnCollectionChanged(NotifyCollectionChangedAction.Replace, originalItem, item, index);
    }
