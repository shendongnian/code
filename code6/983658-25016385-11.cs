    public class AppContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(p => p.Foods).WithRequired(f => f.CookedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Food>().ToTable("Foods");
            modelBuilder.Entity<Book>().ToTable("Books");
        }
    }
