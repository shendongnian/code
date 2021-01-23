    public class Comment
    {
        public int Id { get; set; }
        public int DocId { get; set; }
        public string CommentText { get; set; }
        public virtual Document Document { get; set; } 
    }
