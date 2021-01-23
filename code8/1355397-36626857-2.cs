    public class BookPage
    {
        [Key]
        public string BookPageId { get; set; }
        public int Number { get; set; }
        public PageTitle PageTitle { get; set; }
        public Book Book { get; set; }   // Add FK if desired
    }
