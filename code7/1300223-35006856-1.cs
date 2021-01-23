    public class ObservableGroupingCollection<K, T> where K : IComparable
    {
        public ObservableGroupingCollection(ObservableCollection<T> collection)
        {
            _rootCollection = collection;
            _rootCollection.CollectionChanged += _rootCollection_CollectionChanged;
        }
    
        ObservableCollection<T> _rootCollection;
        private void _rootCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            HandleCollectionChanged(e);
        }
    
        ObservableCollection<Grouping<K, T>> _items;
        public ObservableCollection<Grouping<K, T>> Items
        {
            get { return _items; }
        }
    
        IComparer<T> _sortOrder;
        Func<T, K> _groupFunction;
    
        public void ArrangeItems(IComparer<T> sortorder, Func<T, K> group)
        {
            _sortOrder = sortorder;
            _groupFunction = group;
    
            var temp = _rootCollection
                .OrderBy(i => i, _sortOrder)
                .GroupBy(_groupFunction)
                .ToList()
                .Select(g => new Grouping<K, T>(g.Key, g));
    
            _items = new ObservableCollection<Grouping<K, T>>(temp);
    
        }
    
        private void HandleCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var item = (T)(e.NewItems[0]);
                var value = _groupFunction.Invoke(item);
    
                // find matching group if exists
                var existingGroup = _items.FirstOrDefault(g => g.Key.Equals(value));
    
                if (existingGroup == null)
                {
                    var newlist = new List<T>();
                    newlist.Add(item);
    
                    // find first group where Key is greater than this key
                    var insertBefore = _items.FirstOrDefault(g => ((g.Key).CompareTo(value)) > 0);
                    if (insertBefore == null)
                    {
                        // not found - add new group to end of list
                        _items.Add(new Grouping<K, T>(value, newlist));
                    }
                    else
                    {
                        // insert new group at this index
                        _items.Insert(_items.IndexOf(insertBefore), new Grouping<K, T>(value, newlist));
                    }
                }
                else
                {
                    // find index to insert new item in existing group
                    int index = existingGroup.ToList().BinarySearch(item, _sortOrder);
                    if (index < 0)
                    {
                        existingGroup.Insert(~index, item);
                    }
                }
            }
            else
            {
                var item = (T)(e.OldItems[0]);
                var value = _groupFunction.Invoke(item);
    
                var existingGroup = _items.FirstOrDefault(g => g.Key.Equals(value));
    
                if (existingGroup != null)
                {
                    // find existing item and remove
                    var targetIndex = existingGroup.IndexOf(item);
                    existingGroup.RemoveAt(targetIndex);
    
                    // remove group if zero items
                    if (existingGroup.Count == 0)
                    {
                        _items.Remove(existingGroup);
                    }
                }
            }
        }
    }
