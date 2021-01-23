    public class ViewModel
    {
        List<Feed> feeds = new List<Feed>();
        public ViewModel()
        {
            Feed feed1 = new Feed();
            feed1.Title = "Feed A";
            feed1.Articles = new List<Article>() { new Article() { Title = "Article 1", HeadLine = "Headline 1" },
            new Article() { Title = "Article 2", HeadLine = "Headline 2"},
            new Article() { Title = "Article 3", HeadLine = "Headline 3"}};
            feeds.Add(feed1);
            Feed feed2 = new Feed();
            feed2.Title = "Feed B";
            feed2.Articles = new List<Article>() { new Article() { Title = "Article 4", HeadLine = "Headline 4" }};
            feeds.Add(feed2);
            Feed feed3 = new Feed();
            feed3.Title = "Feed C";
            feed3.Articles = new List<Article>() { new Article() { Title = "Article 5", HeadLine = "Headline 5" },
            new Article() { Title = "Article 6", HeadLine = "Headline 6"}};
            feeds.Add(feed3);
        }
            public List<Feed> Feeds { get { return this.feeds; } }
        }
        public class Feed
        {
            public string Title { get; set; }
            public List<Article> Articles { get; set; }
        }
        public class Article
        {
            public string Title { get; set; }
            public string HeadLine { get; set; }
        }
