    class ConflatingQueue<TKey, TValue> : IEnumerable<TValue>
    {
        private readonly Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
        private readonly Queue<TKey> keys = new Queue<TKey>();
        public void Enqueue(TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
                keys.Enqueue(key);
            }
        }
        public TValue Dequeue()
        {
            var key = keys.Dequeue();
            var value = dict[key];
            dict.Remove(key);
            return value;
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            foreach (var key in keys)
            {
                yield return dict[key];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
