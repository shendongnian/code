    ((INotifyCollectionChanged)_items).CollectionChanged += 
            new NotifyCollectionChangedEventHandler(OnItemCollectionChanged2);
    //the handler
    private void OnItemCollectionChanged2(object sender, NotifyCollectionChangedEventArgs e){
            SetValue(HasItemsPropertyKey, (_items != null) && !_items.IsEmpty);   
            ...
    }
