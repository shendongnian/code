    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<BloggingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
    }
