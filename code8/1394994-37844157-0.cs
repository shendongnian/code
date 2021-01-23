    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ISuperSecretClass, SuperSecretClass>();
    }
    public void Configure(IApplicationBuilder app, ISuperSecretClass instance)
    {
       //do something with instance
    }
