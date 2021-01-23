    public class BlogController : Controller {
        private IBloggingContext _context;
        public BlogController(IBloggingContext bloggingContext) {
            this._context = bloggingContext;
        }
        public IActionResult GetBlog(int id) {
            Blog blog = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return View(blog);
        }
    }
