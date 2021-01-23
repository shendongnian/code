            public static void Register(HttpConfiguration config)
    		{
    			// Web API configuration and services
    
    			// Web API routes
    			config.MapHttpAttributeRoutes();
    
    			config.ParameterBindingRules.Insert(0, JSONParamBinding.HookupParameterBinding);
    
    			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
    		}
