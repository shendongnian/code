    public class Book
    {
      public Author Author { get; set; }
    }
    
    public class Author
    {
      public IList<Book> Books { get; set; }
    }
