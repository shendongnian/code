    public class Data
    {
        public Data()
        {
            _authorsWithBooks = new Lazy<Author[]>(() => _authorData.Select(a => { a.Books = Books.Where(b => b.AuthorID == a.AuthorID).ToArray(); return a; }).ToArray());
        }
    
        private Author[] _authorData;
        private Lazy<Author[]> _authorsWithBooks;
    
        [XmlElement("Author")]
        public Author[] Authors
        {
            get
            {
                return _authorsWithBooks.Value;
            }
            set
            {
                _authorData = value;
            }
        }
    
        [XmlElement("Book")]
        public Book[] Books { get; set; }
    }
    
    
    public class Author
    {
        public string AuthorID { get; set; }
        public string Name { get; set; }
        [XmlIgnore]
        public Book[] Books { get; set; }
    }
    
    public class Book
    {
        public string AuthorID { get; set;}
        public string Name { get; set; }
    }
