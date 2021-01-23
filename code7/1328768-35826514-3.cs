    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string ReviewBody { get; set; }
        public string ReviewHeadLine { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
    }
    
    public class CommentViewModel
    {
        public string CommentBody { get; set; }
    }
