    internal sealed class Configuration : DbMigrationsConfiguration<YourContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
