    public void ConfigureServices(IServiceCollection services)
    {
        // Code omitted        
        services.AddSession(options => { 
                options.IdleTimeout = TimeSpan.FromMinutes(50); 
                options.CookieName = ".FooApplication";
            });
    }
