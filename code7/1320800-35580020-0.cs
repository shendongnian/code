    public void ConfigureServices(IServiceCollection services)
    {    
        var fooValue = Configuration.Get<string>("foo");
        // Add framework services.
        services.AddMvc();
    }
