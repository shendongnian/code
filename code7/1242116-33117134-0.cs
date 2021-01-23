        public class MemoryCacheItemInfo
        {
            public string Key { get; private set; }
            public object CacheItemValue { get; private set; }
            public DateTime Created { get; private set; }
            public DateTime LastUpdateUsage { get; private set; }
            public DateTime AbsoluteExpiry { get; private set; }
            public TimeSpan SlidingExpiry { get; private set; }
            public MemoryCacheItemInfo(string key, object cacheItemValue,
                DateTime created, DateTime lastUpdateUsage, DateTime absoluteExpiry,
                TimeSpan slidingExpiry)
            {
                this.Key = key;
                this.CacheItemValue = cacheItemValue;
                this.Created = created;
                this.LastUpdateUsage = lastUpdateUsage;
                this.AbsoluteExpiry = absoluteExpiry;
                this.SlidingExpiry = slidingExpiry;
            }
        }
