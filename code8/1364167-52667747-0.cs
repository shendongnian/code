        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // here could be several seed services if necessary
                var seedService = scope.ServiceProvider.GetService<ISeedService>();
                await seedService.MigrateAsync();
                await seedService.SeedAsync();
            }
        }
