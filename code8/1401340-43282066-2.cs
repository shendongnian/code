    using StackExchange.Redis;
    using StackExchange.Redis.Extensions.Newtonsoft;
    using StackExchange.Redis.Extensions.Core;
    using System.Linq;
        
        private static Lazy<ConnectionMultiplexer> conn = new Lazy<ConnectionMultiplexer>(
           () => ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisServerMaster"]
             + "," + ConfigurationManager.AppSettings["RedisServerSlave"]
             + "," + ConfigurationManager.AppSettings["RedisOptions"])
        
        public class SessionObjects
        {
            public string SessionId { get; set; }
            public TimeSpan? TTL { get; set; }
        }
        
        List<SessionObjects> lso = new List<SessionObjects>();
        var serializer = new NewtonsoftSerializer();
        StackExchangeRedisCacheClient cacheClient;
        cacheClient = new StackExchangeRedisCacheClient(rConn, serializer, 1);
        IEnumerable<string> keys = cacheClient.SearchKeys("*");
        var db = rConn.GetDatabase(1);
        foreach (var s in keys)
        {
            SessionObjects so = new SessionObjects();
            so.SessionId = s;
            so.TTL = db.KeyTimeToLive(s);
        }
