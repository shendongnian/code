    public class BulkObservableCollection<T> : ObservableCollection<T>
    {
        public BulkObservableCollection()
        {
        }
    
        public BulkObservableCollection(List<T> list) : base(list)
        {
        }
    
        public BulkObservableCollection(IEnumerable<T> collection) : base(collection)
        {
        }
    
        /// <summary>
        /// Adds a range if items to the collection, causing a reset event to be fired.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");
    
            var intialCount = Items.Count;
            Items.AddRange(items);            
            if (Items.Count != intialCount)
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    
        /// <summary>
        /// Removes a range of items from the collection, causing a reset event to be fired.
        /// </summary>
        /// <param name="items"></param>
        public void RemoveRange(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");
    
            var intialCount = Items.Count;
            foreach (var item in items)            
                Items.Remove(item);
            if (Items.Count != intialCount)
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    
        public void Reset(IEnumerable<T> newItems)
        {
            if (newItems == null) throw new ArgumentNullException("newItems");
    
            Items.Clear();
            Items.AddRange(newItems);
    
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
  
