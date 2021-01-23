    public class Post : IEntity
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set;}
    }
    public class PostsRepository : IRepository<Post>
    {
        public void Add(Post entity);
        /// etc
    }
