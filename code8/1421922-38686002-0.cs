    public class PostLike
    {
      public int Id { set; get; }
      public int PostID { get; set; }
      public int UserID { get; set; }
      public virtual Post Post { get; set; }
      public virtual User User { get; set; }
    }
