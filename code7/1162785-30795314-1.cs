    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));
        services.Configure<DbSettings>(Configuration.GetSubKey("DbSettings"));
        services.Configure<EmailSettings>(Configuration.GetSubKey("EmailSettings"));
    }
