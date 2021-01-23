    internal sealed class Configuration : DbMigrationsConfiguration<SID2013Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            CommandTimeout = 360;// <----- 6 minute timeout!
        }
    }
