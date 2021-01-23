    public class LookupDictionary<TKey, TElement> : ILookup<TKey, TElement>
    {
        private readonly IDictionary<TKey, IEnumerable<TElement>> _dic;
        public LookupDictionary(IDictionary<TKey, IEnumerable<TElement>> dic)
        {
            _dic = dic;
        }
        public int Count
        {
            get { return _dic.Count; }
        }
        public IEnumerable<TElement> this[TKey key]
        {
            get { return _dic[key]; }
        }
        public bool Contains(TKey key)
        {
            return _dic.ContainsKey(key);
        }
        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            return _dic.Select(kv => new LookupDictionaryGrouping(kv)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        class LookupDictionaryGrouping : IGrouping<TKey, TElement>
        {
            private KeyValuePair<TKey, IEnumerable<TElement>> _kvp;
            public TKey Key
            {
                get { return _kvp.Key; }
            }
            public IEnumerator<TElement> GetEnumerator()
            {
                return _kvp.Value.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public LookupDictionaryGrouping(KeyValuePair<TKey, IEnumerable<TElement>> kvp)
            {
                _kvp = kvp;
            }
        }
    }
