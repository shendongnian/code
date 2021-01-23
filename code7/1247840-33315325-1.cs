    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                // ...build cors options...
            });
        });
        services.AddMvc();
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseIISPlatformHandler();
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseMvc();
    }
