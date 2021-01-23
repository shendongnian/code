    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(configuration.GetSubKey("AppSettings"));
        services.Configure<DbSettings>(configuration.GetSubKey("DbSettings"));
        services.Configure<EmailSettings>(configuration.GetSubKey("EmailSettings"));
    }
