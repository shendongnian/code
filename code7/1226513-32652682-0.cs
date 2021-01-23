    namespace APP.Migrations
{
    internal class ManualConfiguration : Configuration
    {
        public void ManualSeed(EntitiesDbContext context)
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Entities.EntitiesDbContext, Configuration>());
            Seed(context);
        }
    }
