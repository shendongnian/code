    public class TwoWayDictionary<T>
    {
        private Dictionary<T, T> _first;
        private Dictionary<T, T> _second;
        public TwoWayDictionary()
        {
            _first = new Dictionary<T, T>();
            _second = new Dictionary<T, T>();
        }
        public void Add(T first, T second)
        {
            _first.Add(first, second);
            _second.Add(second, first);
        }
    
        public T this[T value]
        {
            get
            {
                if(_first.ContainsKey(value))
                {
                    return _first[value];
                }
                if(_second.ContainsKey(value))
                {
                    return _second[value];
                }
            
                throw new ArgumentException(nameof(value));
            }
        }
    }
