    private IRedisClientsManager redisClientsManager;
    
    public override void Configure(Funq.Container container)
    {
        // Configure ServiceStack to connect to Redis
        // Replace with your connection details
        redisClientsManager = new PooledRedisClientManager("127.0.0.1:6379");
        container.Register<IRedisClientsManager>(c => redisClientsManager);
        container.Register<ICacheClient>(c => c.Resolve<IRedisClientsManager>().GetCacheClient()).ReusedWithin(Funq.ReuseScope.None);
    
        // Setup the authorisation feature
        Plugins.Add(new AuthFeature(()=> 
            new AuthUserSession(),
            new IAuthProvider[]{ new BasicAuthProvider() }
        ));
    
        // Use a RedisAuthRepository
        var userRepo = new RedisAuthRepository(redisClientsManager);
        container.Register<IUserAuthRepository>(userRepo);
    
        // Enable the RegistrationFeature
        Plugins.Add(new RegistrationFeature());
    }
