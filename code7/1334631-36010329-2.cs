    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }    
        public virtual BlogImage BlogImage { get; set; }
    }
    public class BlogImage
    {
        [Key, ForeignKey("Blog")]
        public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }
    
        public virtual Blog Blog { get; set; }
    } 
