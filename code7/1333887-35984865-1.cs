    class Program
    {
        static void Main(string[] args)
        {
            Blog blogToAdd = new Blog()
            {
                Name = "My Blog",
                Posts = new Post[]
                {
                    new Post()	{Text = "My 1st Post"},
                    new Post()	{Text = "My 2nd Post"},
                    new Post()	{Text = "My 3rd Post"},
                },
            };
            // note: Post.BlogId and Post.Blog are not filled!
            Blog addedBlog = AddBlog(blogToAdd);
            Debug.Assert(addedBlog.Posts != null);
            Debug.Assert(addedBlog.Posts.Count() == blogToAdd.Posts.Count());
        }
        private static Blog AddBlog(Blog blogToAdd)
        {
            using (var dbContext = new BlogContext())
            {
                Blog addedBlog = dbContext.Blogs.Add(blogToAdd);
                dbContext.SaveChanges();
                return addedBlog;
            }
        }
