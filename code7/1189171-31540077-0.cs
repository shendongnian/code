    public class SMISContext : DbContext
    {
        public SMISContext()
            : base("SMISContext")
        {
            Database.SetInitializer<SMISContext>(null);
      
        }
