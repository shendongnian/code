    public class BlogArticleResponse
    {
        public string status { get; set; }
        public int count { get; set; }
        public int pages { get; set; }
        public BlogTag tag { get; set; }
        ...
    }
    public class BlogTag 
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        ...
    }
