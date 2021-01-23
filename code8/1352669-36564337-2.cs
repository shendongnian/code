    public class Author
    {
        public Author()
        {
            AuthorUid = Guid.NewGuid();
        }
        public int AuthorId { get; set; }
        public Guid AuthorUid { get; set; }
        public string FullName { get; set; }
    }
    public class Book
    {
        public Book()
        {
            BookUid = Guid.NewGuid();
            Pages = new List<BookPage>();
        }
        public int BookId { get; set; }
        public Guid BookUid { get; set; }
        public List<BookPage> Pages { get; set; }
        public Author Author { get; set; }
        public string Text { get; set; }
    }
    public class BookPage
    {
        public BookPage()
        {
            BookPageUid = Guid.NewGuid();
        }
        public int BookPageId { get; set; }
        public Guid BookPageUid { get; set; }
        public int Number { get; set; }
    }
