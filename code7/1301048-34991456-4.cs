    public void Configuration(IAppBuilder appBuilder) 
    { 
      // Configure Web API for self-host. 
      HttpConfiguration config = new HttpConfiguration();
      config.DependencyResolver = new UnityDependencyResolver(
          SelfHostWebApiOwin.UnityHelpers.GetConfiguredContainer());
     
      config.Routes.MapHttpRoute( 
                    name: "DefaultApi", 
                    routeTemplate: "api/{controller}/{id}", 
                    defaults: new { id = RouteParameter.Optional } 
                ); 
     
      appBuilder.UseWebApi(config); 
    }
