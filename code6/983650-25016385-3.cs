    public class AppContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(p => p.Foods).WithRequired(f => f.CookedBy).WillCascadeOnDelete(false);
        }
    }
