    public class MyDbContext : System.Data.Entity.DbContext
    {
        static MyDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
        }
    }
