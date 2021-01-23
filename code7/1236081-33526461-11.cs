    public class Reaction 
    {
        public ObjectId Id { get; set; }
        public ObjectId ParentId { get; set;}
        public ObjectId UserId { get; set; }
        public DateTimeOffset Date { get; set; }
        public Bool Likes { get; set; }
    }
