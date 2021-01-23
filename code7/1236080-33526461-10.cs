    public class ReactionCount
    {       
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
    public class Page
    {
        public ObjectId Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public ReactionCount ReactionCount { get; set; }
    }
    public class Post
    {
        public ObjectId Id { get; set; }
        public ObjectId PageId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public ReactionCount ReactionCount { get; set; }
    }
