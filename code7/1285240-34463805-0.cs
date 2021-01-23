    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework()
            .AddDbContext<DbContext>();
      
        services.AddMvc();
    }
