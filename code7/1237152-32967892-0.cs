    internal sealed class Configuration : DbMigrationConfiguration<YourDbContext>
    {
        protected override void Seed(YourDbContext context)
        {
            base.Seed(context);
            context.Database.ExecuteSqlCommand(FileReadAllText("migration.sql"));
        }
    }
