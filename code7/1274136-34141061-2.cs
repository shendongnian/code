    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<AppContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppContext>();
        services.AddScoped<PersonHelper>();
        services.AddMvc();
    }
