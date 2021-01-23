    public class Comment
    {
         public Guid id { get; set; }
         public string content { get; set; }
         public int numComment { get; set; }
         public virtual Post postId { get; set; }
         public virtual ApplicationUser author { get; set; }
     }
    public class Post
    {
         public Guid id { get; set; }
         public string title { get; set; }
         public string content { get; set; }
         public virtual ICollection<ApplicationUser> author { get; set; }
         public virtual ICollection<Comment> comments { get; set; }
         public Comment Commentobject {get;set;}
     }
