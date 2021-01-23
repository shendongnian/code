    public class Like
    {
        public ObjectId Id { get; set; }
        public ObjectId ParentId { get; set;}
        public ObjectId UserId { get; set; }
        public DateTimeOffset DateLiked { get; set; }
    }
