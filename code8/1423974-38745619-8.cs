    public RedisCache : ICache
    {
        private IConnectionMultiplexer connection;
        public bool TryGet<T>(string key, out T value)
        {
            var cache = Connection.GetDatabase();
            var rValue = cache.StringGet(key);
            if (!rValue.HasValue)
            {
                value = default(T);
                return false;
            }
            value = JsonConvert.DeserializeObject<T>(rValue);
            return true;
        }
    
        . . .    
    }
