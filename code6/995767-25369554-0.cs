    public class SuperDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> dictionary;
        private Queue<TKey> keys;
        private int size;
        public SuperDictionary(int size)
        {
            this.keys = new Queue<TKey>(size);
            this.size = size;
            this.dictionary = new Dictionary<TKey, TValue>();
        }
        public void Add(TKey key, TValue value)
        {
            if (dictionary.Count >= size)
            {
                var oldestKey = keys.Dequeue();
                dictionary.Remove(oldestKey);
            }
            
            dictionary.Add(key, value);
            keys.Enqueue(key);
        }
        public TValue this[TKey key]
        {
            get { return dictionary[key]; }
        }
    }
