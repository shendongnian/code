    public void ConfigureServices(IServiceCollection services) {    
        services.AddDbContextPool<YourDbContext>(options => {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(this.Configuration.GetConnectionString("MyCon"));
        });
    }
    
