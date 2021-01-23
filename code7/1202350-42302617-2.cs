    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    
            //add the authorization handler to the pipeline
            config.MessageHandlers.Add(new new ApiAuthHandler()());
        }
    }
