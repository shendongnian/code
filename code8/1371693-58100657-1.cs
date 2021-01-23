    public static class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var services = new ServiceCollection()
                .AddSingleton<ISearchService, SearchService>() // Add your dependencies
                .BuildServiceProvider();
            config.DependencyResolver = new DefaultDependecyResolver(services);
        }
    }
