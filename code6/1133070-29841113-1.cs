    public class ImageContent: IModel
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
    }
    public class ImageContentList
    {
        public ImageContentList()
        {
            Images = new List<ImageContent>();
        }
        public List<ImageContent> Images { get; set; } 
    }
    
    public class CategoryPostModel : ImageContentList
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
