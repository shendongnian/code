    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
    public class Book
    {
       private Author _author { get; set; }
       public Book(Author author)
       {
         _author = author;
       }
       public void PrintBookAuthor()
       {
         Console.WriteLine(_author.AuthorName);
       }
    }
