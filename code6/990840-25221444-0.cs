     public class UserPosts
     {
         [Key]
         public int PostId { get; set; }
         [ForeignKey("User")]
         public string CreatedBy { get; set; }
         public virtual UserBio User { get; set; }
 
         public string Description { get; set; }
     }
