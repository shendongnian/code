    class YourContext : DbContext
    {
        static YourContext()
        {
            Database.SetInitializer<YourContext>(YourMigratingDatabaseInitializer);
            using (var context = new YourContext())
            {
                context.Database.Initialize(false);
            }
        }
        public YourContext()
        {
            Database.SetInitializer<YourContext>(null);
        }
    }
