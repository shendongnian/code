    public class ImageData
    {
       public string OldUrl { get; set; }
       public string NewUrl { get; set; }
    }
    public class ImageController : ApiController
    {
       // Gets 2 images - old and new
       public ImageData GetNew(string id)
       {
          return new ImageData
          {
             OldUrl = "/images/old/" + id,
             NewUrl = "/images/new/" + id,
          };
       }
    }
