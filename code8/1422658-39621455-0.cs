    public void ConfigureServices(IServiceCollection services)
    {
        ...
        
        string dbConnectionString = services.GetConnectionString("YOUR_PROJECT_CONNECTION");
        string assemblyName = typeof(ProjectDbContext).Namespace;
        services.AddDbContext<ProjectDbContext>(options =>
            options.UseSqlServer(dbConnectionString,
                optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(assemblyName)
            )
       );
       ...
    }
