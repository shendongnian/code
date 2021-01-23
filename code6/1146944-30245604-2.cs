    internal class MyInitializer : CreateDatabaseIfNotExists<ConfigurationDbContext>
    {
        protected override void Seed(ConfigurationDbContext context)
        {
            SeedAsync(context).Wait();
        }
        protected async Task SeedAsync(ConfigurationDbContext context)
        {
            await DbHelper.AddSampleDataAsync(context);
            base.Seed(context)
        }
    }
