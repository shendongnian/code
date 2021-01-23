    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        services.AddTransient<MyClass>();        
        services.AddTransient<AnotherClass>();
        //Other configurations removed for brevity
    }
