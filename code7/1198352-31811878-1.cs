    public class FakeFastDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        protected IList<KeyValuePair<TKey, TValue>> _list
            = new List<KeyValuePair<TKey, TValue>>();
        public new void Add(TKey key, TValue value)
        {
            _list.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
        public new ICollection<TValue> Values
        {
            get
            {
                // there may be faster ways to to it:
                return _list.Select(x => x.Value).ToArray();
            }
        }
        public new ICollection<TKey> Keys
        {
            get
            {
                // there may be faster ways to to it:
                return _list.Select(x => x.Key).ToArray();
            }
        }
    }
	
