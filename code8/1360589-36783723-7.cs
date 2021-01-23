    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore()
            .AddJsonFormatters()
            .AddApiExplorer();
            
        services
            .AddEntityFramework()
            .AddInMemoryDatabase()
            .AddDbContext<TestDbContext>(); // register a service
        services.AddScoped<ITestRepository, TestRepository>();
        services.AddSwaggerGen();
    }
