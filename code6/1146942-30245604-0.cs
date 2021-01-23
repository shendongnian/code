    internal class MyInitializer : CreateDatabaseIfNotExists<ConfigurationDbContext>
    {
        protected override void Seed(ConfigurationDbContext context)
        {
            //anything extra if needed
            base.Seed(context);
        }
        protected async Task SeedAsync(ConfigurationDbContext context)
        {
            await DbHelper.AddSampleDataAsync(context);
            base.Seed(context)
        }
    }
