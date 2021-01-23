    using System.Linq;
    var serializer = new NewtonsoftSerializer();
    StackExchangeRedisCacheClient cacheClient;
    cacheClient = new StackExchangeRedisCacheClient(rConn, serializer, 1);
    IEnumerable<string> keys = cacheClient.SearchKeys("*");
    count = keys.Count();
