    public class Service 
    {
        private IRedisClient redis;
        public virtual IRedisClient Redis
        {
            get { return redis ?? (redis = RedisManager.GetClient()); }
        }
        public virtual void Dispose()
        {
            if (redis != null)
                redis.Dispose();
        }
    }
