    using System.Web.Http;
    using MvcApplication1.Controllers;
    
    namespace MvcApplication1
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
                config.MessageHandlers.Add(new ValuesController.EncodingDelegateHandler());
    
                config.EnableSystemDiagnosticsTracing();
            }
        }
    }
