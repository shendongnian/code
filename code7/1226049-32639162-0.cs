    [XmlRoot("Books")]
    public class BooksResponse
    {
        [XmlElement("Book")]
        public Book[] Book_Items { get; set; }
    }
