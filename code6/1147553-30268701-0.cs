    public void ConfigureServices(IServiceCollection services)
	{
	    services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));
        // ...
    }
