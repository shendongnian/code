    public class Emotions
    {       
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
    public class Page
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public Emotions Emotions { get; set; }
    }
    public class Post
    {
        public ObjectId Id { get; set; }
        public ObjectId PageId { get; set; }
        public string Message { get; set; }
        public Emotions Emotions { get; set; }
    }
