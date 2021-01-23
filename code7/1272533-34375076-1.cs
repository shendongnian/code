    services.AddEntityFramework()
    .AddSqlServer()
    .AddDbContext<ExampleContext>(options => 
        options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]).
        MigrationsAssembly("Example.Api"));
