    public class Comment
    {
      public int Id{get;set;}
      public int? ParentCommentId{get;set;}
    
      public virtual Comment ParentComment{get;set;}
      public virtual ICollection<Comment> Comments{get;set;}
    }
