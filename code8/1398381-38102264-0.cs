       [TestMethod]
        public void CreateBlog_saves_a_blog_via_context()
        {
            var mockContext = new Mock<BloggingContext>();
            // Add related posts directly into fake blog data
            var data = new List<Blog>
            {
                new Blog {Name = "BBB", Posts = new List<Post>() { new Post() { Title = "Post1"} } },
                new Blog {Name = "ZZZ", Posts = new List<Post>() { new Post() { Title = "Post2"} } },
                new Blog {Name = "AAA", Posts = new List<Post>() { new Post() { Title = "Post3"} } },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Blog>>();
            mockSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);
            var service = new BlogService(mockContext.Object);
            var newBlog = new Blog {Name = "A New Blog", Posts = new List<Post>() {new Post() {Title = "Post1"}}};
            // Add new Blog to service
            service.AddBlog(newBlog);
            // Check that DbContext received the new blog correctly
            // And Blog contained correct name and Post count of 1
            mockSet.Verify(x=>x.Add(It.Is<Blog>(blog=>blog.Name == "A New Blog" && blog.Posts.Count == 1)));
        }
