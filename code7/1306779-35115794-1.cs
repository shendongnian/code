    public class BlogPostViewModel
    {
        public string BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
