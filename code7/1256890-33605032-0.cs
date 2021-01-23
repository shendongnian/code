    public class Post
    {
    	[Key]
    	public int Id { get; set; }
    	
    	public string Title { get; set; }
    	
        public DateTime DateTime { get; set; }
    	
        public string Body { get; set; }
    
    	public virtual ICollection<PostTag> PostTags { get; set; }
    }
    
    public class Tag
    {
    	[Key]
    	public int Id { get; set; }
    	
    	[Required]
    	[MaxLength(128)]
    	[Index(IsUnique = true)]
    	public String Name { get; set; }
    
    	public virtual ICollection<PostTag> TagPosts { get; set; }
    }
    
    public class PostTag
    {
    	[Key]
    	public int Id { get; set; }
    
    	[Required]
    	[Index("IX_PostTag", 1, IsUnique = true)]
    	public int PostId { get; set; }
    
    	[Required]
    	[Index("IX_PostTag", 2, IsUnique = true)]
    	public int TagId { get; set; }
    
    	[ForeignKey("PostId")]
    	public virtual Post Post { get; set; }
    
    	[ForeignKey("TagId")]
    	public virtual Tag Tag { get; set; }
    }
