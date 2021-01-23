    public class Post
    {
      public int ID{get;set;}
      // ...
      public virtual ICollection<View> Views{get;set;}
    }
    public class View
    {
      public int ID{get;set;}
      public int PostID{get;set;}
      // ...
      public virtual Post Post{get;set;}
    }
