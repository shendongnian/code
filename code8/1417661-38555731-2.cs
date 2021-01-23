    public class BookData
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }
        public string Id { get; set; }
    }
    public class GetBooksResult
    {
        public string draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public BookData[] data { get; set; }
    }
