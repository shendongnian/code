    class TwitterDateConverter : IsoDateTimeConverter
    {
        public TwitterDateConverter()
        {
            DateTimeFormat = "ddd MMM dd HH:mm:ss zzz yyyy";
        }
    }
    
    public class TweetModel
    {
    	[JsonConverter(typeof(TwitterDateConverter))]
    	[JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
