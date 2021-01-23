    public void ConfigureServices(IServiceCollection services){
        services.Configure<ConfigurationOptions(Configuration);
        services.AddSingleton<IDocumentDbRepository, DocumentDbRepository>();
        // ...
    
    }
