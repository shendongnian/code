    public class MySuperClass
    {
        public static IRedisClientsManager RedisManager = 
            new RedisManagerPool("localhost:6379");
    }
