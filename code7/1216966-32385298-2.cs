    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            string alphanumeric = @"^[a-zA-Z]+[a-zA-Z0-9,_ -]*$";
            string numeric = @"^\d+$";
            config.Routes.MapHttpRoute(
               name: "DefaultApiControllerActionName",
               routeTemplate: "api/{controller}/{action}/{name}",
               defaults: null,
               constraints: new { action = alphanumeric }
            );
            config.Routes.MapHttpRoute(
               name: "DefaultApiControllerActionId",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: null,
               constraints: new { action = alphanumeric, id = numeric }
            );
        }
    }
