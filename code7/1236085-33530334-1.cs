    public class Person
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Page
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<Like> PersonLikes { get; set; }
        public List<Post> Posts { get; set; }
    }
        
    public class Post
    {
        public ObjectId Id { get; set; }
        public string Message { get; set; }
        public List<Like> Likes { get; set; }
    }
    public class Like
    {
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public DateTime DateLiked { get; set; }
    }
