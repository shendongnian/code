    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            // More config...
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // More config...
        }
        protected override System.Web.Http.Dependencies.IDependencyResolver BuildWebApiDependencyResolver()
        {
            var resolver = base.BuildWebApiDependencyResolver();
            var springResolver = resolver as SpringWebApiDependencyResolver;
            if (springResolver != null)
            {
                var resource = new AssemblyResource(
                    "assembly://assemblyName/namespace/ChildControllers.xml");
                springResolver.AddChildApplicationContextConfigurationResource(resource);
            }
            return resolver;
        }
    }
