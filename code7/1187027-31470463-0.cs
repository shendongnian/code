    Database.SetInitializer(new MigrateDatabaseToLatestVersion<BloggingContext, BloggingContextMigrationConfiguration>(true));
    internal sealed class BloggingContextMigrationConfiguration : DbMigrationsConfiguration<BloggingContext>
    {
        public BloggingContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
