      public sealed class Comment
    {
        public string CommentText { get; set; }
        public DateTime PostDate { get; set; }
        public int PostId { get; set; }
        public int? PageId { get; set; }
        public Page Page { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public int? ParentId { get; set; }
        public Comment[] ChildComments { get; set; }
    }  
