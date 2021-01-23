    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddSessionStateTempDataProvider();
        services.AddSession();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseSession();
        app.UseMvcWithDefaultRoute();
    }
