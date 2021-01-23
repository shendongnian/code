       //Configure Services
       public void ConfigureServices(IServiceCollection services)
       {
    		// Add framework services.
    		services.AddMvc(options => {
    			options.Filters.Add(typeof(common.Filters.ApiInjectFilter), 0);       //My Filter is added here with order 0 (first)
    		});  
    		.......
       }
