    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IHelloMessage, HelloMessage>();
    }
    
    public void Configure(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await Task.Run(() =>
            {
                new ResponseWriter(app.ApplicationServices.GetRequiredService<IHelloMessage>()).Write(context);
            });
        });
    }
