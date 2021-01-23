    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddDbContext<ConfigurationRepository>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
        services.AddScoped<IConfigurationBL, ConfigurationBL>();
        services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
    }
