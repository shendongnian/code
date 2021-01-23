	public class BlogCommandHandler : ICommandHandler<LikeBlogPostCommand>
	{
		// Injection not shown
		private IRepository<BlogPost> _repository;
		
		public void HandleCommand(LikeBlogPostCommand command)
		{
			var blogPost = _repository.FindById(command.BlogPostId);
			blogPost.AddRating(command.Score);
			_repository.Save();		
		}		
	}
