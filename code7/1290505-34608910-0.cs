    class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        public void AddRange(int startingIndex, IEnumerable<T> items)
        {
            var notifier = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items.ToList(), startingIndex);
            foreach (var item in items)
            {
                // insert to the underlying collection to avoid change events
                Items.Insert(startingIndex++, item);
            }
            OnCollectionChanged(notifier);
        }
        public void RemoveRange(int startingIndex, int count)
        {
            // Do it yourself
        }
    }
