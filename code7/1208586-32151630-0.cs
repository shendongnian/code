    public class MultiKeyDictionary<T>
    {
        private Dictionary<int, T> _indexDictionary = new Dictionary<int, T>();
        private Dictionary<string, T> _keyDictionary = new Dictionary<string, T>();
        
        public int Count
        {
            get { return _indexDictionary.Count; }
        }
        public T this[string key]
        {
            get
            {
                T result;
                if (!TryGetValue(key, out result))
                {
                    throw new IndexOutOfRangeException();
                }
                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public T this[int key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Add(int index, string key, T value)
        {
            _indexDictionary.Add(index, value);
            _keyDictionary.Add(key, value);
        }
        public void Clear()
        {
            _indexDictionary.Clear();
            _keyDictionary.Clear();
        }
        public bool Contains(T item)
        {
            return _indexDictionary.ContainsValue(item);
        }
        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }
        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(string key, out T value)
        {
            var result = _keyDictionary.TryGetValue(key, out value);
            return result;
        }
        public bool TryGetValue(int key, out T value)
        {
            var result = _indexDictionary.TryGetValue(key, out value);
            return result;
        }
    }
