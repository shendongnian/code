    public sealed class TwoWayDictionary<TKey, TValue> : DictionaryBase
    {
        Hashtable reverseLookup = new Hashtable();
        public void Add(TKey key, TValue value)
        {
            this.Dictionary.Add(key, value);
        }
        public void Remove(TKey key)
        {
            this.Dictionary.Remove(key);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            object lookup = Dictionary[key];
            if (lookup == null)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                value = (TValue)lookup;
                return true;
            }
        }
        public bool TryGetKey(TValue value, out TKey key)
        {
            object lookup = reverseLookup[value];
            if (lookup == null)
            {
                key = default(TKey);
                return false;
            }
            else
            {
                key = (TKey)lookup;
                return true;
            }
        }
        protected override void OnInsertComplete(object key, object value)
        {
            reverseLookup.Add(value, key);
        }
        protected override void OnSetComplete(object key, object oldValue, object newValue)
        {
            if(reverseLookup.Contains(newValue))
                throw new InvalidOperationException("Duplicate value");
            if(oldValue != null)
                reverseLookup.Remove(oldValue);
            reverseLookup[newValue] = key;
        }
        protected override void OnRemoveComplete(object key, object value)
        {
            reverseLookup.Remove(value);
        }
    }
