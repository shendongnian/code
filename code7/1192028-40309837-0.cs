    public static class ConcurrentDictionaryExtensions
    {
        private static readonly object myLock = new object();
        public static TValue GetOrAddIfNotNull<TKey, TValue>(
            this ConcurrentDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> valueFactory) where TValue : class
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
            {
                lock (myLock)
                {
                    value = dictionary.GetOrAdd(key, valueFactory);
                    if (value == null) dictionary.TryRemove(key, out value);
                } 
            }
            return value;
        }
    }
