    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public Dbset<ApplicationUser> Users { get; set; }
        public overridee OnModelCreating(DbModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Book>()
            .HasRequired(b => b.CreatedByUser)
            .WithMany()
            .HasForeignKey(b => b.CreatedBy);
        }
    }
    public class Book
    {
      public int CreatedBy { get; set; }
      public virtual ApplicationUser CreatedByUser { get; set; }
    }
