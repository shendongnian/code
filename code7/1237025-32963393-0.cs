    #define NONEST
    
    void Main()
    {
    	string baseAddress = "http://localhost:9000/";
    
        try
        {
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();
    
                var response = client.GetAsync(baseAddress + "api/values").Result;
    
                Console.WriteLine("response: " + response);
                Console.WriteLine("result: " + response.Content.ReadAsStringAsync().Result);
            }
        }
        finally
        {
            // LinqPad keeps the AppDomain running to reduce compile time. 
            // Force app domain unload (Displays "Query ended unexpectedly")
            // You can also press shift-F5 to unload the AppDomain.
            AppDomain.Unload(AppDomain.CurrentDomain);
        }
    }
    
    // Define other methods and classes here
    
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
    	public void Configuration(IAppBuilder appBuilder)
    	{
    		// Configure Web API for self-host. 
    		HttpConfiguration config = new HttpConfiguration();
    
    		config.Routes.MapHttpRoute(
    			name: "DefaultApi",
    			routeTemplate: "api/{controller}/{id}",
    			defaults: new { id = RouteParameter.Optional }
    		);
    	
    		appBuilder.UseWebApi(config);
    	}
    }
    
    public class ValuesController : ApiController
    {
    	// GET api/values 
    	public IEnumerable<string> Get()
    	{
    		return new string[] { "value1", "value2" };
    	}
    }
