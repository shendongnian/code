    public class RedisDatabaseService<T> : IRedisDatabase<T> where T : class, IConfig
    {
        public RedisDatabaseService()
        {
            // Move your lazy assignment to the constructor, as so:
            lazyConfig =  new Lazy<T>(InitConfig);
        }
    
        public Lazy<T> lazyConfig { get; private set; } 
        public T InitConfig()
        {
            throw new NotImplementedException();
        }
    
    }
    
    public interface IRedisDatabase<T> where T : class
    {
        T InitConfig();
    }
