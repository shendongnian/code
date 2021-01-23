    public class Book
    {
      public string Title {get; private set;}
      private ImmutableList<Author> authors;
      public IReadOnlyList<Author> Authors { get { return authors; } }
      public string ISBN {get; private set; }
      
      public Book(string title, IEnumerable<Author> authors, string ISBN) : this(
        title, 
        ImmutableList<Author>.Empty.AddRange(authors),
        ISBN) {}
      public Book(string title, ImmutableList<Authors> authors, string ISBN) 
      {
        this.Title = title;
        this.Authors = authors;
        this.ISBN = ISBN;
      }
      public Book WithTitle(string newTitle)
      {
        return new Book(newTitle, authors, ISBN); 
      }
      public Book WithISBN(string newISBN)
      {
        return new Book(Title, authors, newISBN);
      }
      public Book WithAuthor(Author author)
      {
        return new Book(Title, authors.Add(author), ISBN);
      }
      public static readonly Empty = new Book("", ImmutableList<Author>.Empty, "");
    }
