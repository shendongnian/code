	public class Post
	{
		public int Id { get;set; }
		public string Title { get; set; }
		// Other properties etc.
		
		public virtual ICollection<ImageFile> Images { get; set; }
	}
	public class ImageFile
	{
		public int Id { get; set; }
		public byte[] ImageBytes { get; set; }
		
		[ForeignKey(nameof(Post))]
		public int PostId { get; set; }
		
		[ForeignKey(nameof(PostId))]
		public Post Post { get; set; }
	}
