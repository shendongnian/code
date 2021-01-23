    public class Post
    {
    	[Key]
    	public int PostId { get; set; }
    	.
    	public int ThreadId { get; set; }
    	[ForeignKey("ThreadId")]
    	public virtual Thread Thread { get; set; }
    }
