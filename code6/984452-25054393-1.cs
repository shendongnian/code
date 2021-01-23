    var observableCollection = new ObservableCollection<Item>();
    var throttledObservableCollection = new ThrottledObservableCollection<Item>(
      observableCollection,
      TimeSpan.FromSeconds(1)
    );
    throttledObservableCollection.CollectionChanged += ...
    // 2 CollectionChanged events will fire from this code.
    observableCollection.Add(new Item());
    observableCollection.Add(new Item());
    Thread.Sleep(TimeSpan.FromSeconds(1.1));
    observableCollection.Add(new Item());
