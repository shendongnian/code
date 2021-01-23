    [Serializable]
    public class Book
    {
        //BookId, Category, Title, Author, Publisher, Description, Price, ISBN, PublicationDate.
        public Author Author { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
        public int Price { get; set; }
        public string PublicationDate { get; set; }
    }
