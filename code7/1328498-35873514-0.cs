    internal sealed class Configuration : DbMigrationsConfiguration<TimsDB>
    {
        public Configuration()
        {
            if ("true".Equals(Environment.GetEnvironmentVariable("RUN_SEED")))
                using (TimsDB db = new TimsDB())
                {
                    Database.SetInitializer<TimsDB>(null);
                    Seed(db);
                }
            }
        }
        ...
    }
