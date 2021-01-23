    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Routes and other stuff here...
    
            var container = IocContainer.Instance; // Or any other way to fetch your container.
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
