    public class LinkedDataContext : DbContext
    {
        public DbSet<LinkedData> LinkedData { get; set; }
        public LinkedDataContext() : base("DefaultConnection")
        {
        }
    }
