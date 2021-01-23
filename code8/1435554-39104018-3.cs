    public class AutoIndexedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        private readonly Dictionary<TKey, TValue> inner;
        private readonly Func<TKey, TKey> incrementor;
        private readonly Stack<TKey> freeKeys;
        private readonly TKey keySeed;
        private TKey currentKey;
        public AutoIndexedDictionary(TKey keySeed, Func<TKey, TKey> incrementor) 
        {
            if (keySeed == null)
                throw new ArgumentNullException(nameof(keySeed));
            if (incrementor == null)
                throw new ArgumentNullException(nameof(incrementor));
            inner = new Dictionary<TKey, TValue>();
            freeKeys = new Stack<TKey>();
            currentKey = keySeed;
        }
        public TKey Add(TValue value) //returns the used key
        {
            TKey usedKey;
            if (freeKeys.Count > 0)
            {
                usedKey = freeKeys.Pop();
                inner.Add(usedKey, value);
            }
            else
            {
                usedKey = currentKey;
                inner.Add(usedKey, value);
                currentKey = incrementor(currentKey);
            }
            return usedKey;
        }
        public void Clear()
        {
            inner.Clear();
            freeKeys.Clear();
            currentKey = keySeed;
        }
        public bool Remove(TKey key)
        {
            if (inner.Remove(key))
            {
                if (inner.Count > 0)
                {
                    freeKeys.Push(key);
                }
                else
                {
                    freeKeys.Clear();
                    currentKey = keySeed;
                }
                return true;
            }
            return false;
        }
        public bool TryGetValue(TKey key, out TValue value) => inner.TryGetValue(key, out value);
        public TValue this[TKey key] => inner[key];
        public bool ContainsKey(TKey key) => inner.ContainsKey(key);
        public bool ContainsValue(TValue value) => inner.ContainsValue(value);
        public int Count => inner.Count;
        public Dictionary<TKey,TValue>.KeyCollection Keys => inner.Keys;
        public Dictionary<TKey, TValue>.ValueCollection Values => inner.Values;
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => inner.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)inner).GetEnumerator();
    }
