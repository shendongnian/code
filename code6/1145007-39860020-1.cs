    internal sealed class Configuration : DbMigrationsConfiguration<PricedNotesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SynapseDomain.DAL.PricedNotesContext";
        }
        protected override void Seed(PricedNotesContext context)
        {
        }
    }
