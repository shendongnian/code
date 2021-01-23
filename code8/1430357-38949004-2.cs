    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Load the first connection string
        var connectionStringA = Configuration["Data:DefaultConnection:ConnectionStringA"];
        // Load the second connection string
        var connectionStringB = Configuration["Data:DefaultConnection:ConnectionStringB"];
        // Set up Entity Framework
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<ContextA>(options => options.UseSqlServer(connectionStringA))
            .AddDbContext<ContextB>(options => options.UseSqlServer(connectionStringB));
    }
