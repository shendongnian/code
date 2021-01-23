    public class Book
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public IList<Chapter> Chapters{ get; set; }
        public Book()
        {
            Chapters = new List<Chapter>();
        }
    }
