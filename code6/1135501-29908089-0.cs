	void Main()
	{
		Blog myBlog = new Blog();
		
		myBlog.Posts
			  .SelectMany(post => post.Comments)
			  .Select(comment => comment.Id)
			  .ToList()
			  .ForEach(Console.WriteLine);
	}
	
	public class Blog
	{
		public Blog()
		{
			Posts = new List<Post>
			{
				new Post(),
				new Post(),
				new Post(),
			};
		}
		
		public List<Post> Posts { get; set; }
	}
	
	public class Post
	{
		public Post()
		{
			Comments = new List<Comment>
			{
				new Comment(),
				new Comment(),
			};
		}
		public List<Comment> Comments { get; set; }
	}
	
	public class Comment
	{
		public Comment()
		{
			this.Id = Guid.NewGuid().ToString("n");
		}
		public string Id { get; set; }
		
		public override string ToString()
		{
			return this.Id;
		}
	}
