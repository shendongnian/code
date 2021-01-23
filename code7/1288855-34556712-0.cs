    using Microsoft.Data.Entity;
    
    namespace apiservice.Models {
        public class BookContext : DbContext {
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }
        }
    }
