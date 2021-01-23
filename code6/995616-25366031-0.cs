    Library.Add(new Book(bookTitle, bookAuthor));
    public class Book
    {
       public Book(String title, String author)
       {
          Title = title;
          Author = author;
       }
       public String Title { get; private set; }
       public String Author { get; private set; }
    }
