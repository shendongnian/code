    public class ExtendedCommentFile
    {
        private readonly CommentFile _comment;
        public ExtendedComment(CommentFile comment)
        {
            _comment = comment;
        }
        public int UserId
        {
            get { return _comment.UserId; }
            set { _comment.UserId = value; }
        }
        
        public User User
        {
            get { return LoadTheUserHereOrInVM(); }
        }
        public string Username
        {
            get { return LoadTheUserNameHereOrInVM(); }
        }
    }
    /// <summary>
    /// This is the unchangeable commentfile class
    /// </summary>
    public class CommentFile
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    /// <summary>
    /// This is unchangeable user class
    /// </summary>
    public class User
    {
    }
