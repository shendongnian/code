    public sealed class LimitedSizeSortedList<T>: IEnumerable<T>
    {
        readonly int _size;
        readonly SortedSet<T> _items;
        public LimitedSizeSortedList(IComparer<T> comparer, int size)
        {
            if (size < 1)
                throw new ArgumentException();
            _size  = size;
            _items = new SortedSet<T>(comparer);
        }
        public void Add(T item)
        {
            if (_items.Contains(item))
                return;
            if (_items.Count < _size)
            {
                _items.Add(item);
                return;
            }
            if (_items.Comparer.Compare(item, _items.Min) <= 0)
                return;
            _items.Remove(_items.Min);
            _items.Add(item);
        }
        public void Clear()
        {
            _items.Clear();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
