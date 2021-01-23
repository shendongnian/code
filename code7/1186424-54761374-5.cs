    public class ArticleContainer
    {
        public int ShownArticlesCount { get; set; }
        public List<Article> Articles { get; set; }
    }
    public class Article
    {
        public string Title { get; set; }
        public string ThumbnailLink { get; set; }
        public string AuthorName { get; set; }
        public string AuthorProfileLink { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
        public string Link { get; set; } 
    }
