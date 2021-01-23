    using Microsoft.Extensions.PlatformAbstractions;
    
    namespace MyWebApp
    {
        public class Startup
        {		
    	    private IApplicationEnvironment _appEnv { get; set; }
    
    	    public Startup(IHostingEnvironment env)
            {
                // Set up configuration sources.
                var builder = new ConfigurationBuilder()				
                    .AddJsonFile("appsettings.json")
    			    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false);
    
                if (env.IsDevelopment())
                {
                    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                    builder.AddUserSecrets();
                }
    
                builder.AddEnvironmentVariables();			
                Configuration = builder.Build();
    		
                // obtain IApplicationEnvironment instance
    		    _appEnv = PlatformServices.Default.Application;
    
    	    }
    ...
    
