    public class MyCollection<T> : ReadOnlyObservableCollection<T>
    {
      public MyCollection([NotNull] ObservableCollection<T> list) : base(list) {}
      protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
      {
        base.OnCollectionChanged(args);
        OnMyCollectionChanged(args);
      }
      public event NotifyCollectionChangedEventHandler MyCollectionChanged;
      protected virtual void OnMyCollectionChanged(NotifyCollectionChangedEventArgs e)
      {
        NotifyCollectionChangedEventHandler handler = MyCollectionChanged;
        if (handler != null) handler(this, e);
      }
    }
