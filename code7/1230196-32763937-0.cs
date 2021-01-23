    public class MultiKeyDictionary<TFirstKey, TSecondKey, TValue>
    {
        private readonly Dictionary<TFirstKey, TValue> firstKeyDictionary = 
            new Dictionary<TFirstKey, TValue>();
        private readonly Dictionary<TSecondKey, TFirstKey> secondKeyDictionary = 
            new Dictionary<TSecondKey, TFirstKey>();
        public TValue this[TFirstKey idx]
        {
            get
            {
                return firstKeyDictionary[idx];
            }
            set
            {
                firstKeyDictionary[idx] = value;
            }
        }
        public TValue this[TSecondKey idx]
        {
            get
            {
                var firstKey = secondKeyDictionary[idx];
                return firstKeyDictionary[firstKey];
            }
            set
            {
                var firstKey = secondKeyDictionary[idx];
                firstKeyDictionary[firstKey] = value;
            }
        }
        public IEnumerable<KeyValuePair<TFirstKey, TValue>> GetKeyValuePairsOfFirstKey()
        {
            return firstKeyDictionary.ToList();
        }
        public IEnumerable<KeyValuePair<TSecondKey, TValue>> GetKeyValuePairsOfSecondKey()
        {
            var r = from s in secondKeyDictionary
                join f in firstKeyDictionary on s.Value equals f.Key
                select new KeyValuePair<TSecondKey, TValue>(s.Key, f.Value);
            return r.ToList();
        }
        public void Add(TFirstKey firstKey, TSecondKey secondKey, TValue value)
        {
            firstKeyDictionary.Add(firstKey, value);
            secondKeyDictionary.Add(secondKey, firstKey);
        }
        public bool Remove(TFirstKey firstKey)
        {
            if (!secondKeyDictionary.Any(f => f.Value.Equals(firstKey))) return false;
            var secondKeyToDelete = secondKeyDictionary.First(f => f.Value.Equals(firstKey));
            
            secondKeyDictionary.Remove(secondKeyToDelete.Key);
            firstKeyDictionary.Remove(firstKey);
            return true;
        }
        public bool Remove(TSecondKey secondKey)
        {
            if (!secondKeyDictionary.ContainsKey(secondKey)) return false;
            var firstKey = secondKeyDictionary[secondKey];
            secondKeyDictionary.Remove(secondKey);
            firstKeyDictionary.Remove(firstKey);
            return true;
        }
    }
