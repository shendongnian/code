    class ThrottledObservableCollection<T> : IReadOnlyCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged, IDisposable {
    
      List<T> _list;
    
      IDisposable _subscription;
    
      public ThrottledObservableCollection(ObservableCollection<T> source, TimeSpan throttleInterval) {
        if (source == null)
          throw new ArgumentNullException("source");
        _list = new List<T>(source);
        _subscription = Observable
          .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
            handler => source.CollectionChanged += handler,
            handler => source.CollectionChanged -= handler
          )
          .Throttle(throttleInterval)
          .Subscribe(HandleSourceChanged);
      }
    
      void HandleSourceChanged(EventPattern<NotifyCollectionChangedEventArgs> eventPattern) {
        var source = (IEnumerable<T>) eventPattern.Sender;
        _list = new List<T>(source);
        OnPropertyChanged("Count");
        OnCollectionChanged();
      }
    
      public Int32 Count { get { return _list.Count; } }
    
      public IEnumerator<T> GetEnumerator() {
        return _list.GetEnumerator();
      }
    
      IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected void OnPropertyChanged(String propertyName) {
        var handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    
      public event NotifyCollectionChangedEventHandler CollectionChanged;
    
      protected void OnCollectionChanged() {
        var handler = CollectionChanged;
        if (handler != null)
          handler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
      }
    
      public void Dispose() {
        Dispose(true);
      }
    
      protected void Dispose(Boolean disposing) {
        _subscription.Dispose();
      }
    
    }
