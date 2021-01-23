    public class YourContext : DbContext
    {
        ...
        public DbSet<ItemModel> ItemModels { get; set; }
    }
