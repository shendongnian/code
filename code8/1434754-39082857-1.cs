    class Book
    {
        public string Title { get; set; } // This is an automatic property
        public string Author { get; set; }
    }
    
    class BookList
    {
        private var books = new List<Book>();
     
        public bool AddBook (string title, string author)
        {
             books.Add(new Book { Title = title, Author = author });
             return true;
        }
    }
    
    static void Main(string[] args)
    {
        var bookList = new BookList();
        bookList.AddBook ("Mehmet", "Ali");
    }
