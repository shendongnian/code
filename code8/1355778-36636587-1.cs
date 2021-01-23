    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        services.AddTransient<MyClass>();        
        //Other configurations removed for brevity
    }
