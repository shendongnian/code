    public void ConfigureServices(IServiceCollection services)
    {
        // .....
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<School360DbContext>(provider =>
        {
            return ResolveDbContext(provider, hostingEnv);
        });
        // ..
    }
    
    private MyDbContext ResolveDbContext(IServiceProvider provider, IHostingEnvironment hostingEnv)
    {
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
    
        string SOME_DB_IDENTIFYER = httpContextAccessor.HttpContext.User.Claims
            .Where(c => c.Type == "[SOME_DB_IDENTIFYER]").Select(c => c.Value).FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(SOME_DB_IDENTIFYER))
        {
            connectionString = connectionString.Replace("[DB_NAME]", $"{SOME_DB_IDENTIFYER}Db");
        }
    
        var dbContext = new DefaultDbContextFactory().CreateDbContext(connectionString);
    
        // ....
        return dbContext;
    }
