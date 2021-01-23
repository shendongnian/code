        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["Data:BlogData:ConnectionString"]))
            .AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:Identity:ConnectionString"]));
