    public class Post
    {
        public int PostID { get; set; }
        public Guid UserID { get; set; }
        public int ThreadID { get; set; }
        public string PostTitle { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostBody { get; set; }
    
        public Post( DateTime initialValue)
        {
             PostDateTime = initialValue;
        }
    }
