    services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(Configuration["Data:OtherConnection:ConnectionString"]));
