    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddDataProtection(); //Add this
    	[..]
    	services.AddMvc();
    }
