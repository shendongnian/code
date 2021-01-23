    public delegate void CountEqual(object sender, EventArgs e);
    
    public class ObservableCountCollection<T>: ObservableCollection<T>
    {
        public CountEqual CountUnchanged;
    
        private int _previousCount;
        private object locker = new object();
    
        public ObservableCountCollection()
        {
            this.CollectionChanged += ObservableCountCollection_CollectionChanged;
            _previousCount = 0;
        }
    
        void ObservableCountCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            bool raiseEvent = false;
            var unchanged = CountUnchanged;
            lock(locker)
            {
                raiseEvent = _previousCount == this.Count;
                _previousCount = this.Count;
            }
            if (raiseEvent && unchanged!=null)
            {
                unchanged(this, new EventArgs());
            }
        }
    }
