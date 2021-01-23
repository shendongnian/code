        IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(
                ConfigurationManager.ConnectionStrings["Database"].ConnectionString,
                SqlServerDialect.Provider
                );
        // Register the main database as the default singleton
        container.Register<IDbConnectionFactory>(dbFactory);
            IDbConnectionFactory dbCacheFactory = new OrmLiteConnectionFactory(
                
        // Create a second factory, but ONLY use it to instantiate the Cache
        ConfigurationManager.ConnectionStrings["BottleDropCache"].ConnectionString,
                SqlServerDialect.Provider
                );
        var cache = new OrmLiteCacheClient();
        cache.DbFactory = dbCacheFactory;
        cache.InitSchema();
        container.Register<ICacheClient>(cache);
