    public class Page
    {
        public ObjectId Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public int NumberOfLikes { get; set; }
    }
    public class Post
    {
        public ObjectId Id { get; set; }
        public ObjectId PageId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public int NumberOfLikes { get; set; }
    }
