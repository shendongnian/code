    public class AppContext : DbContext
    {
        public DbSet<Item> Items { get; set; } // --> this dbset is required for TPT, if removed it will become TPCC
        public DbSet<Food> Books { get; set; }
        public DbSet<Book> Foods { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new BookMap());
        }
    }
    public class ItemMap : EntityTypeConfiguration<Food>
    {
        public ItemMap()
        {
            ToTable("Foods");
        }
    }
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Books");
        }
    }
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Food : Item { }
    public class Book : Item { }
