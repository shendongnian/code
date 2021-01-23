        services
            .AddEntityFramework()
            .AddDbContext<MyDbContext>(
                options =>
                { options.UseSqlite(connection); });
