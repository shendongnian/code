    public class Comment
    {
    	[JsonProperty("author_flair_text")]
        public string AuthorFlairText { get; set; }
    	
    	[JsonProperty("author_flair_text")]
        public string AuthorFlairCssClass { get; set; }
    	
    	[JsonProperty("author")]
    	public string Author { get; set; }
    	
    	[JsonProperty("link_id")]
        public string LinkId { get; set; }
    	
    	[JsonProperty("id")]
        public string Id { get; set; }
    	
    	[JsonProperty("body_html")]
        public string BodyHtml { get; set; }
    	
    	[JsonProperty("url")]
        public string Url { get; set; }
    	
    	[JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }
    	
    	[JsonProperty("subreddit")]
        public string Subreddit { get; set; }
    	
    	[JsonProperty("created_utc")]
        public long CreatedUtc { get; set; }
    	
    	[JsonProperty("body")]
        public string Body { get; set; }
    	
    	[JsonProperty("parent_id")]
        public string ParentId { get; set; }
    }
