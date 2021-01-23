    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int BlogImageId { get; set; }
        public BlogImage BlogImage { get; set; }
    }
    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }    
        public Blog Blog { get; set; }
    } 
