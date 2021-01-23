	public class BlogPost
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime DateTime { get; set; }
		
		public int PosCommentId {get; set; }
		public List<PostComment> PostComments { get; set; }
	}
