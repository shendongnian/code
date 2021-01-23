    public class DatabaseMigrationConfig
    {
        internal static void Register()
        {
            using (var context = new MyContext(Config.ConnectionStringMigrations))
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext,
                                            Migrations.Configuration>());
                context.Database.Initialize(false);
            }
        }
    }
