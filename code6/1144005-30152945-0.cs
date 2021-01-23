    public void ConfigureServices(IServiceCollection services)
    {
        // Add EF services to the services container
                    
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<Your__DB__Context__Class>(options =>
                            options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString")));
        }
        //... other services...
    }
