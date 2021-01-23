    public static class ConcurrentDictionaryExtensions
    {
        private static readonly object myLock = new object();
        public static TValue GetOrAddIfNotNull<TKey, TValue>(
            this ConcurrentDictionary<TKey, TValue> dictionary,
            TKey key, 
            Func<TKey, TValue> valueFactory) where TValue : class
        {
            lock (myLock)
            {
                var value = dictionary.GetOrAdd(key, valueFactory);
                if (value == null) dictionary.TryRemove(key, out value);
                return value;
            }
        }
    }
