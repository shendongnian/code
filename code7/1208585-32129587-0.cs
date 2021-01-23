    public class SynchronizedObservableCollection<T> : ObservableCollection<T>
    {
        private SynchronizationContext synchronizationContext;
        public SynchronizedObservableCollection()
        {
            synchronizationContext = SynchronizationContext.Current;
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            synchronizationContext.Send((object state) => base.OnCollectionChanged(e), null);
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            synchronizationContext.Send((object state) => base.OnPropertyChanged(e), null);
        }
        protected override void ClearItems()
        {
            synchronizationContext.Send((object state) => base.ClearItems(), null);
        }
        protected override void InsertItem(int index, T item)
        {
            synchronizationContext.Send((object state) => base.InsertItem(index, item), null);
        }
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            synchronizationContext.Send((object state) => base.MoveItem(oldIndex, newIndex), null);
        }
        protected override void RemoveItem(int index)
        {
            synchronizationContext.Send((object state) => base.RemoveItem(index), null);
        }
        protected override void SetItem(int index, T item)
        {
            synchronizationContext.Send((object state) => base.SetItem(index, item), null);
        }
    }
