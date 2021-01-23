    public class PostComment
    {
        public int Id { get; set; }
        public BlogPost ParentPost { get; set; }
        // //
        public int? ParentPostId { get; set; }
        // //
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
    }
