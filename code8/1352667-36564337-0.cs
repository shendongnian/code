    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookPage> BookPages { get; set; }
        public DbSet<Author> Authors { get; set; }
        ...
    }
