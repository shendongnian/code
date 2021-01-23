    private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
        return ConnectionMultiplexer.Connect("mycache.redis.cache.windows.net,abortConnect=false,ssl=true,password=...");
    });
    
    public static ConnectionMultiplexer Connection {
        get {
            return lazyConnection.Value;
        }
    }
