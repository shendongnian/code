    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
    
            // Convention-based routing.
    
            #region DataAPI
    
            var ns = new[] { "ERP.Controllers.DataAPI" };
            config.Routes.MapHttpRoute(
                name: "DataAPI",
                routeTemplate: "DataAPI/Community/{ApiKey}",
                defaults: new {controller= "Commmunity", action = "GetCommunities",  ApiKey = Guid.Empty},
                namespaces: ns
            );
            #endregion
    
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
