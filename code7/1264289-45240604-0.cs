    {
        services.AddMvc();
        // Adds a default in-memory implementation of IDistributedCache.
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            // Set a short timeout for easy testing.
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.CookieHttpOnly = true;
        });
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
        app.UseMvcWithDefaultRoute();
    }
