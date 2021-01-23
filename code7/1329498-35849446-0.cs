    using System.Collections.Immutable;
    ...
    public class Book
    {
      public string bookTitle {get; private set;}
      private ImmutableList<Author> authors;
      public IReadOnlyList<Author> Authors { get { return authors; } }
      public string ISBN {get; private set; }
      
      public Book(string bookTitle, IEnumerable<Author> authors, string ISBN)
      {
        this.authors = ImmutableList<Author>.Empty.AddRange(authors);
        this.bookTitle = bookTitle;
        this.ISBN = ISBN;
      }
    }
