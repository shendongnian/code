    public static class WebApiConfig
    {   
            public static void Register(HttpConfiguration config)
            {
                    config.Routes.MapHttpRoute(
                                name: "API TokenEndpoint",
                                routeTemplate: "services/newtoken/{grantType}",
                                defaults: new { controller = "Token" action="Post"},
                                constraints: null);
            }   
    }
