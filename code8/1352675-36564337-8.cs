    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookPage> BookPages { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        ...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasAlternateKey(a => a.AuthorUid);
            modelBuilder.Entity<Book>().HasAlternateKey(a => a.BookUid);
            modelBuilder.Entity<BookPage>().HasAlternateKey(a => a.BookPageUid);
        }
    }
