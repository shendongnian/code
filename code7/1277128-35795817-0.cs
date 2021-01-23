    public class ad_hook
    {
        [Fact]
        public async Task test_redis_load()
        {
            var repository = GetRedis();
            int expected;
            IEnumerable<Task<string>> tasks;
            using (var redisRepository = repository)
            {
                redisRepository.Set("foo", "boo");
                expected = 10000;
                tasks = Enumerable.Range(1, expected).Select(_ => Task.Run(() => redisRepository.Get<string>("foo")));
                var items = await Task.WhenAll(tasks);
                items.Should().OnlyContain(s => s == "boo")
                    .And.HaveCount(expected);
            }
        }
        private static RedisRepository GetRedis()
        {
            var repository = new RedisRepository();
            return repository;
        }
    }
    public class RedisRepository : IDisposable
    {
        private Lazy<IRedisClient> clientFactory;
        private PooledRedisClientManager clientManager;
        private T Run<T>(Func<IRedisClient, T> action)
        {
            using (var client = GetRedisClient())
            {
                return action(client);
            }
        }
        private IRedisClient GetRedisClient()
        {
            return clientManager.GetClient();
        }
        public RedisRepository()
        {
            clientFactory = new Lazy<IRedisClient>(GetRedisClient);
            clientManager = new PooledRedisClientManager();
        }
        public void Set<T>(string key, T entity)
        {
            Run(_ => _.Set(key, entity));
        }
        public T Get<T>(string key)
        {
            return Run(_ => _.Get<T>(key));
        }
        public void Dispose()
        {
            clientManager.Dispose();
            if (clientFactory.IsValueCreated)
            {
                clientFactory.Value.Dispose();
            }
        }
    }
