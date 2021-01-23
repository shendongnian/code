    public void ConfigureServices(IServiceCollection services)
    {
    	//...
    	services.AddDataProtection();
    	services.ConfigureDataProtection(configure =>
    	{
		    configure.SetApplicationName("YourAppName");
	    });
	    //...
    }
	public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			//...
			
            app.UseCookieAuthentication(options =>
            {
                options.LoginPath = new PathString("/");
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.ExpireTimeSpan = new TimeSpan(1, 0, 0);
                options.SlidingExpiration = true;
            });
            //...
        }
