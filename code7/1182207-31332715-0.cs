    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Press Press { get; set; }
        public List<Parameter> Properties { get; set; }
    }
    public class BooksController : ODataController
    {
        private IList<Book> _books = new List<Book>
        {
            new Book
            {
                ISBN = "978-0-7356-7942-9",
                Title = "Microsoft Azure SQL Database Step by Step",
                Properties = new List<Parameter>
                {
                    new Parameter { Key = "k1", Value = "v1" },
                    new Parameter { Key = "k2", Value = "v2" }
                }
            },
            new Book
            {
                ISBN = "978-0-7356-8383-9",
                Title = "SignalR",
                Press = new Press
                {
                    Name = "Microsoft Press",
                    Category = Category.Book
                },
                Properties = new List<Parameter>
                {
                    new Parameter { Key = "k1", Value = "v1" }
                }
            }
        };
        [EnableQuery]
        public IQueryable<Book> Get()
        {
            return _books.AsQueryable();
        }
    }
