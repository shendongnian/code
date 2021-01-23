        class Program
        {
           public class Library
           {
             [Key]
             public int LibraryId { get; set; }
             public List<Library2Book> Library2Books { get; set; } = new    List<Library2Book>();
           }
    
           public class Book
           {
             [Key]
             public int BookId { get; set; }
             public List<Library2Book> Library2Books { get; set; } = new List<Library2Book>();
           }
    
           public class Library2Book
           {
             [Key]
             public int BookId { get; set; }
             public Book Book { get; set; }
    
             [Key]
             public int LibraryId { get; set; }
             public Library Library { get; set; }
           }
    
           public class MyDbContext : DbContext
           {
             public DbSet<Book> Books { get; set; }
    
             public DbSet<Library> Libraries { get; set; }
    
             protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             {
               optionsBuilder.UseSqlServer(@"Server=.\;Database=EFTutorial;integrated security=True;");
               base.OnConfiguring(optionsBuilder);
            }
    
             protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
               modelBuilder.Entity<Library2Book>().HasKey(k => new { k.LibraryId, k.BookId });
    
               modelBuilder.Entity<Library2Book>()
                   .HasOne(x => x.Book)
                   .WithMany(x => x.Library2Books)
                   .HasForeignKey(x => x.BookId);
    
               modelBuilder.Entity<Library2Book>()
                  .HasOne(x => x.Library)
                  .WithMany(x => x.Library2Books)
                  .HasForeignKey(x => x.LibraryId);
    
               base.OnModelCreating(modelBuilder);
             }
           }
    
           static void Main(string[] args)
           {
             using (var myDb = new MyDbContext())
            {
              // Create Db
               myDb.Database.EnsureCreated();
    
               // I will add two books to one library
               var book1 = new Book();
               var book2 = new Book();
    
               // I create the library 
               var lib = new Library();
    
               // I create two Library2Book which I need them 
               // To map between the books and the library
               var b2lib1 = new Library2Book();
               var b2lib2 = new Library2Book();
    
               // Mapping the first book to the library.
               b2lib1.Book = book1;
               b2lib2.Library = lib;
    
               // I map the second book to the library.
               b2lib2.Book = book2;
               b2lib2.Library = lib;
    
               // Linking the books (Library2Book table) to the library
               lib.Library2Books.Add(b2lib1);
               lib.Library2Books.Add(b2lib2);
    
               // Adding the data to the DbContext.
               myDb.Libraries.Add(lib);
    
               myDb.Books.Add(book1);
               myDb.Books.Add(book2);
    
               // Save the changes and everything should be working!
               myDb.SaveChanges();
             }
           }
        }
