     public class Author
    {
        [Key]
        public int id { get; set; }        
        [Required(ErrorMessage = "You Need to Enter A Author Name ")]
        public string AuthorName { get; set; }
        public string Address { get; set; }
        public virtual List<book> books{ get; set; }
       
    }
    public class Book
    {
        public int id { get; set; }
        public string BookName { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateofPublish { get; set; }
        public int id { get; set; }
        public virtual Author Author{ get; set; }
    }
    public class LibraryDb: DbContext
    {
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Book> Books{ get; set; }
        public LibraryDb() : base("LibraryDb") { }
    }
