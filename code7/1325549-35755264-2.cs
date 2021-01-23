        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            var container = new UnityContainer();
            container.RegisterType<IDataProvider, DataProvider>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            return config;
        }
