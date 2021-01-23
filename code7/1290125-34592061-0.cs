    public class Document {
        public int Id { get; set; } // No need for [Key] ID is auto detected
        public string Name { get; set; }
        
        // Foreign Keys
        public int AuthorId { get; set; } // Can use "int?" if you want to allow it to be nullable
        public User Author { get; set; }
    }
    public class Author {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BookContext : DbContext {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
