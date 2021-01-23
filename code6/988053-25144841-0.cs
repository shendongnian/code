	public class WebApiInitializer : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {    
            RouteTable.Routes.MapHttpRoute(
                "CreateJob",
                "api/msi/SBJob/CreateJob",
                defaults: new {Controller = "SBKob", Action = "CreateJob"}
                );
				
            RouteTable.Routes.MapHttpRoute(
                "GetJob",
                "api/msi/SBJob/GetJob",
                defaults: new {Controller = "SBKob", Action = "CreateJob"}
                );				
        }
    }
