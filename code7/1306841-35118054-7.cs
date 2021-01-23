    internal sealed class Configuration : DbMigrationsConfiguration<ScripterEngine.DataAccessLayer.CampaignContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
