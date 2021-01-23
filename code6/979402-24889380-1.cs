    public class YourContext : DbContext
    {
        public YourContext() : base("YourContextConnection")
        {
            Database.SetInitializer<YourContext>(null);
        }
        //Rest of context here
    }
