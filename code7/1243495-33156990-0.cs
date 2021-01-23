	public class LikeBlogPostCommand
	{
		public int BlogPostId { get; private set; }
		public int Score { get; private set; }
		
		public LikeBlogPostCommand(int blogPostId, int score)
		{
			BlogPostId = blogPostId;
			Score = score;
		}
	}
