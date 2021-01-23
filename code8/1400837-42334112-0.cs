          public void ConfigureServices(IServiceCollection services)
            {
     var connectionString = Startup.Configuration["connectionStrings:DBConnectionString"];//this line is not that relevant, the most important thing is registering the DbContext
                services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
    }
