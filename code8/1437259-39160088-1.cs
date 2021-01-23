    public void ConfigureServices(IServiceCollection services)
    {   
        // Add framework services.
        services.AddMvc();
        // Setup options with DI
        services.AddOptions();
        services.Configure<AzureStorageConfig>(Configuration.GetSectio("AzureStorageConfig"));
    }
