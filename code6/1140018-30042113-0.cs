    public class FilteredObservableCollection<T> : ObservableCollection<T>
    {
        private Predicate<T> _filter;
        public FilteredObservableCollection(ObservableCollection<T> source, Predicate<T> filter)
            : base(source.Where(item => filter(item)))
        {
            source.CollectionChanged += source_CollectionChanged;
            _filter = filter;
        }
        private void _Fill(ObservableCollection<T> source)
        {
            foreach (T item in source)
            {
                if (_filter(item))
                {
                    Add(item);
                }
            }
        }
        private int this[T item]
        {
            get
            {
                int foundIndex = -1;
                for (int index = 0; index < Count; index++)
                {
                    if (this[index].Equals(item))
                    {
                        foundIndex = index;
                        break;
                    }
                }
                return foundIndex;
            }
        }
        private void source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
            case NotifyCollectionChangedAction.Add:
                foreach (T item in e.NewItems)
                {
                    if (_filter(item))
                    {
                        Add(item);
                    }
                }
                break;
            case NotifyCollectionChangedAction.Move:
                // Without a lot more work maintaining the view state, it would be just as hard
                // to figure out where the moved item should go, as it would be to just regenerate
                // the whole view. So just do the latter.
                _Fill((ObservableCollection<T>)sender);
                break;
            case NotifyCollectionChangedAction.Remove:
                foreach (T item in e.OldItems)
                {
                    // Don't bother looking for the item if it was filtered out
                    if (_filter(item))
                    {
                        Remove(item);
                    }
                }
                break;
            case NotifyCollectionChangedAction.Replace:
                for (int index = 0; index < e.OldItems.Count; index++)
                {
                    T item = (T)e.OldItems[index];
                    if (_filter(item))
                    {
                        int foundIndex = this[item];
                        if (foundIndex != -1)
                        {
                            this[foundIndex] = (T)e.NewItems[index];
                        }
                    }
                }
                break;
            case NotifyCollectionChangedAction.Reset:
                _Fill((ObservableCollection<T>)sender);
                break;
            }
        }
    }
