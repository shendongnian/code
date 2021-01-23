    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IFooService>();
    }
    public void Configure(IApplicationBuilder app, IFooService fooService)
    {
        fooService.Bar();
    }
