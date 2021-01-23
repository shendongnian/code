    public class Collection<TKey> where TKey : class
    {
        public ICollection<KeyValuePair<TKey, object>> Col { get; set; }
    
        public void Add(TKey key, object value)
        {
            Col.Add(new KeyValuePair<TKey, object>(key, value));
        }
    }
