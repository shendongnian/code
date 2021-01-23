    public class MemberComment
    {
        [Key]
        public int MemberCommentID { get; set; }
    
        [ForeignKey]
        public int MemberID { get; set; }
        [ForeignKey]
        public int CommentID { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Comment Comment { get; set; }
    
        public int Something { get; set; }
        public string SomethingElse { get; set; }
    }
