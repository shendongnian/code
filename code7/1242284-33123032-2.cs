    using Microsoft.Practices.Unity;
    using System.Web.Http;
    using System.Web.Mvc;
    namespace WebApplication1
    {
        public static class UnityConfig
        {
            public static void RegisterComponents()
            {
                var container = new UnityContainer();
    
                // register all your components with the container here
                // it is NOT necessary to register your controllers
    
                // e.g. container.RegisterType<ITestService, TestService>();
    
                // Configures container for ASP.NET MVC
                DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
    
                // Configures container for WebAPI
                GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            }
        }
    }
