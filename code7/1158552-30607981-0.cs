    public class Comment
    {
      public int Id{get;set;}
      public int? ParentCommentId{get;set;}
    
      public virtual Parent ParentComment{get;set;}
      public virtual ICollection<Parent> Comments{get;set;}
    }
