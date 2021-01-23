    public void ConfigureServices(IServiceCollection services)
    {
       // ...
       services.AddSession();
       // ...
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
        app.UseMvc();
        // ...
    }
