    public class MyContext : DbContext
    {
        public MyContext() : base("Default")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MigrateDBConfiguration>());
        }
        
        ...
    }
