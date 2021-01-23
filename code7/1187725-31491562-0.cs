    namespace WebApp.Models
    {
      public class News
      {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          
          [ForeignKey("Picture")]
          public int PictureId { get; set; }
          public virtual Picture Picture { get; set; }
          
          // not sure why this is here
          public int guid { get; set; }
      }
    
      public class Picture
      {
          public int Id { get; set; }
          
          public byte[] ImageData { get; set; }
          public string ContentType { get; set; }
          
          public int width { get; set; }
          public int height { get; set; }
          public int hash { get; set; }
      }
    }
    
