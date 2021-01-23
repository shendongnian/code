    namespace SearchWebAPI.DependencyResolution {
        using StructureMap;
    	
        public static class IoC {
            public static IContainer Initialize() {
                return new Container(c => c.AddRegistry<DefaultRegistry>());
            }
        }
    }
    namespace SearchWebAPI.DependencyResolution
    {
        using StructureMap.Configuration.DSL;
        using StructureMap.Graph;
        using SearchWebAPI.Models;
    
        public class DefaultRegistry : Registry
        {
            #region Constructors and Destructors
    
            public DefaultRegistry()
            {
                Scan(
                    scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                        scan.With(new ControllerConvention());
                    });
            }
    
            #endregion
        }
    }
    namespace SearchWebAPI
    {
        using SearchWebAPI.DependencyResolution;
        using StructureMap;
        using System.Web.Http;
        using System.Web.Mvc;
        public class WebApiApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                App_Start.StructuremapMvc.Start();
    
                //StructureMap Container
                IContainer container = IoC.Initialize();
    
                //Register for MVC
                DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
    
                //Register for Web API
                GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
            }
        }
    }
