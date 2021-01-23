    public class BookChapter
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<BookPage> pages { get; set; }
        //public List<Enrichment> enrichment { get; set; }
        public List<SubChapter> chapters { get; set; }
        public bool IsExpanded { get; set; }
    }
