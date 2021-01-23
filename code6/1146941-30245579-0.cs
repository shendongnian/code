    internal class MyInitializer : CreateDatabaseIfNotExists<ConfigurationDbContext>
    {
        protected override void Seed(ConfigurationDbContext context)
        {
            DbHelper.AddSampleDataAsync(context).Wait();
            base.Seed(context);
        }
    }
