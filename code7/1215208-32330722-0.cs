    internal sealed class MyMigrationConfiguration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
	        CommandTimeout = 10000; // migration timeout
        }
    }
