    public static void Register(HttpConfiguration config)
    {
    	var corsAttr = new System.Web.Http.Cors.EnableCorsAttribute("http://localhost:7185", "*", "*");
    	config.EnableCors(corsAttr);
    
    	config.MapHttpAttributeRoutes();
    
    	config.Routes.MapHttpRoute(
    		name: "DefaultApi",
    		routeTemplate: "api/{controller}/{id}",
    		defaults: new { id = RouteParameter.Optional }
    	);
    }
