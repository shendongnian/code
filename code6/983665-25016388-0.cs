    var collection = new ObservableCollection<Int32>();
    var observable = Observable
      .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
        handler => collection.CollectionChanged += handler,
        handler => collection.CollectionChanged -= handler
      );
