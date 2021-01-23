    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MigrateDBConfiguration>());
        }
        
        ...
    }
    public class MigrateDBConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<MyContext>
    {
        ...
