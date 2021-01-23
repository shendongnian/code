    public class IndexedSet<T> : IReadOnlyList<T>, IList<T>
    {
        private readonly List<T> _list = new List<T>();
        private readonly HashSet<T> _set = new HashSet<T>();
    
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    
        public int Add(T item)
        {
            if (_set.Add(item))
            {
                _list.Add(item);
                return _list.Count - 1;
            }
    
            return _list.IndexOf(item);
        }
    
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }
    
        public void Clear()
        {
            _list.Clear();
            _set.Clear();
        }
    
        public bool Contains(T item)
        {
            return _set.Contains(item);
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
    
        public bool Remove(T item)
        {
            bool remove = _set.Remove(item);
            if (remove)
                _list.Remove(item);
            return remove;
        }
    
        public int Count => _list.Count; 
    
        public bool IsReadOnly => false; 
    
        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }
    
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
    
        public void RemoveAt(int index)
        {
            T item = _list[index];
            _list.RemoveAt(index);
            _set.Remove(item);
        }
    
        public T this[int index]
        {
            get { return _list[index]; }
            set
            {
                T item = _list[index];
                _set.Remove(item);
    
                _list[index] = value;
                _set.Add(value);
            }
        }
    }
