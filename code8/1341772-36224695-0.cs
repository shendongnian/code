    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
    
            // Convention-based routing.
    
            #region DataAPI
    
            var ns = new[] { "ERP.Controllers.DataAPI" };
            config.Routes.MapRoute(
                name: "DataAPI",
                url: "DataAPI/{controller}/{ApiKey}/{id}",
                defaults: new {  ApiKey = Guid.Empty, id = RouteParameter.Optional },
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
