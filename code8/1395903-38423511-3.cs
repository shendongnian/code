    public class BlogControllerTest {
        private IBloggingContext _context;
        private BlogController _controller;
        public BlogControllerTest() {
            //creating seed objects
            var post = new Post() {
                PostId = 1,
                Title = "Some title",
                Content = "post contemt"
            };
            var blog = new Blog() {
                BlogId = 1,
                Url = "google",
                Posts = new List<Post>() { post }
            };
            //associating blog with post
            post.Blog = blog;
            post.BlogId = blog.BlogId;
            var blogsMock = new List<Blog>() { blog }.AsDbSetMock();
            var postsMock = new List<Post>() { post }.AsDbSetMock();
            var contextMock = new Mock<IBloggingContext>();
            contextMock.Setup(m => m.Blogs).Returns(blogsMock.Object);
            contextMock.Setup(m => m.Posts).Returns(postsMock.Object);
            _context = contextMock.Object;
            _controller = new BlogController(_context);
        }
        [Fact]
        public void Get_blog_1_returns_google() {
            // Act
            var result = _controller.GetBlog(1) as ViewResult;
    
            // Assert
            Assert.IsType(typeof(Blog), result.ViewData.Model);
            Blog model = (Blog)result.ViewData.Model;
            Assert.Equal("google", model.Url);
        }
    }
