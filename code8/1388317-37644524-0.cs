    using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var db = serviceScope.ServiceProvider.GetService<MusicStoreContext>();
        if (await db.Database.EnsureCreatedAsync())
        {
            await InsertTestData(serviceProvider);
            if (createUsers)
            {
                await CreateAdminUser(serviceProvider);
            }
        }
    }
