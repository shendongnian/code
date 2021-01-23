    public class Foo : IDisposable
    {
        private readonly IList<Bar> bar1Collection = new ObservableCollection<Bar>();
        public IList<Bar> Bar1Collection
        {
            get
            {
                return bar1Collection;
            }
        }
        private readonly IList<Bar> bar2Collection = new ObservableCollection<Bar>();
        public IList<Bar> Bar2Collection
        {
            get
            {
                return bar2Collection;
            }
        }
        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    if (item is Bar)
                    {
                        var bar = item as Bar;
                        bar.Parent = null;
                    }
                }
            }
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is Bar)
                    {
                        var bar = item as Bar;
                        bar.Parent = this;
                    }
                }
            }
        }
        protected void RegisterCollection(INotifyCollectionChanged collection)
        {
            if (collection == null)
            {
                return;
            }
            collection.CollectionChanged += OnCollectionChanged;
        }
        protected void UnregisterCollection(INotifyCollectionChanged collection)
        {
            if (collection == null)
            {
                return;
            }
            collection.CollectionChanged -= OnCollectionChanged;
        }
        public Foo()
        {
            RegisterCollection(Bar1Collection as INotifyCollectionChanged);
            RegisterCollection(Bar2Collection as INotifyCollectionChanged);
        }
        private bool isDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || isDisposed)
            {
                return;
            }
            isDisposed = true;
            UnregisterCollection(Bar1Collection as INotifyCollectionChanged);
            UnregisterCollection(Bar2Collection as INotifyCollectionChanged);
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
