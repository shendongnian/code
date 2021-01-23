    public void ConfigureServices(IServiceCollection services)
    	{
    		....
    		services.AddSession(options =>
    		{
    			options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
    			options.Cookie.HttpOnly = true;
    			options.Cookie.IsEssential = true;
    		});
    		...
    	}
		
	
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    	{
    		app.UseSession();
    		app.UseMvc();
    	}
	
