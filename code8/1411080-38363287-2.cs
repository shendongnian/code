    void Configure(IApplicationBuilder app)
    {
        //Populates the MusicStore sample data
        SampleData.InitializeMusicStoreDatabaseAsync(app.ApplicationServices).Wait();
    }
    public static class SampleData
    {
        ...
        public static async Task InitializeMusicStoreDatabaseAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
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
        }
    }
