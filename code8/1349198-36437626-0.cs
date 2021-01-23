    public static class RedisProvider
    {
        public static IRedisClientManager Pool { get; set; }
        public static RedisClient GetClient()
        {
            return (RedisClient)Pool.GetClient();
        }
    }
