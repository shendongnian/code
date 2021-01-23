    public class CacheProvider 
    {
        private static CancellationTokenSource _resetCacheToken = new CancellationTokenSource();
        private readonly IMemoryCache _innerCache;
        /* other method and ctor removed for brevity */
        public T Set<T>(object key, T value) 
        {
            /* some other code removed for brevity */
            var options = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal).SetAbsoluteExpiration(typeExpiration);
            options.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));
            _innerCache.Set(CreateKey(type, key), value, options);
            return value;
        }
        public void Reset()
        {
            if (_resetCacheToken != null && !_resetCacheToken.IsCancellationRequested && _resetCacheToken.Token.CanBeCanceled)
            {
                _resetCacheToken.Cancel();
                _resetCacheToken.Dispose();
            }
            
            _resetCacheToken = new CancellationTokenSource();
        }
    }
