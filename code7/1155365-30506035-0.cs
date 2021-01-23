    public class AModel
    {
       public string ImageName { get; set; }
       public string Photo { get { return ImageName == null ? "myDefaultImage.png" : ImageName; }}
    }
