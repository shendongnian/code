    class Post
    {
        public int Id { get; set; }
        
        // Initialize to prevent NullReferenceException
        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
   
    class Comment
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }        
    }
