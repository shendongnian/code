    public class CachedItem<T>
    {
        private readonly T _item; 
        private readonly DateTime _expirationTime;
        public CachedItem(T obj, TimeSpan cacheDuration)
        {
            _item = obj;
            _expirationTime = DateTime.Now.Add(cacheDuration);
        }
        public bool IsExpired { get { return DateTime.Now > _expirationTime; } }
        public T Item
        {
            get
            {
                if (IsExpired)
                    throw new InvalidOperationException("Expired Cached Items cannot be retrieved.");
                return _item;
            }
        }
    }
