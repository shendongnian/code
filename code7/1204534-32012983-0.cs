    public class Startup
    {
    	
    	public void Configuration(IAppBuilder app)
    	{
    		app.UseCors(_corsOptions.Value);
    		app.MapSignalR(); 
    	}
    
    
    	private static Lazy<CorsOptions> _corsOptions = new Lazy<CorsOptions>(() =>
    	{
    		return new CorsOptions
    		{
    			PolicyProvider = new CorsPolicyProvider
    			{
    				PolicyResolver = context =>
    				{
    					var policy = new CorsPolicy();
    					policy.Origins.Add("http://localhost:8081");
    					policy.AllowAnyMethod = true;
    					policy.AllowAnyHeader = true;
    					policy.SupportsCredentials = true;
    					return Task.FromResult(policy);
    				}
    			}
    		};
    	});
    
    }
