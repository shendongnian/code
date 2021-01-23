        // Tell the DbContext where to find the migrations classes
        services.AddDbContext<MyDbContext>(
        options => options.UseSqlServer(
         Configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptions =>
        sqlServerOptions.MigrationsAssembly("MyApp.Migrations")));
