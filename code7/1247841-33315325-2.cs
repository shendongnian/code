    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddMvc();
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseIISPlatformHandler();
        app.UseStaticFiles();
        app.UseCors(builder =>
        {
            // ...default cors options...
        });
        app.UseMvc();
    }
