    public class Context : DbContext
    {
        public DbSet<Item> items { get; set; }
        public Context()
            : base("Demo")
        {
        }
    }
