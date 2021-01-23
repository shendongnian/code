            var cfg2 = Configuration["Data:DashboardContext:ConnectionString"];
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DashboardContext>(options =>
                {
                    options.UseSqlServer(cfg2);
                })
    
