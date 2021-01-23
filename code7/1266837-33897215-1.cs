    public static void Register(HttpConfiguration config)
    {
        // Unity configuration
        var container = new UnityContainer();
        container.RegisterType<IRepository , CustomRepository>();
        config.DependencyResolver = new UnityResolver(container);
        //this
        config.DependencyResolver = new UnityDependencyResolver(container);
        // Web API routes
        // CORS
    }
