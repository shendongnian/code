    public class Author
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Book> Books { get; set; } 
    }
    
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public IEnumerable<BookDetail> Details { get; set; }
    }
    public class BookDetail
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
