    public class TwoWayDictionary<T, K>
    {
        private readonly Dictionary<T, K> _first;
        private readonly Dictionary<K, T> _second;
        public TwoWayDictionary()
        {
            _first = new Dictionary<T, K>();
            _second = new Dictionary<K, T>();
        }
        public void Add(T first, K second)
        {
            _first.Add(first, second);
            _second.Add(second, first);
        }
        public K this[T value]
        {
            get
            {
                if (_first.ContainsKey(value))
                {
                    return _first[value];
                }
                throw new ArgumentException(nameof(value));
            }
        }
        public T this[K value]
        {
            get
            {
                if (_second.ContainsKey(value))
                {
                    return _second[value];
                }
                throw new ArgumentException(nameof(value));
            }
        }
    }    
