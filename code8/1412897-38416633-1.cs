    [Authorize]
    public class BlogsController : Controller
    {
        private readonly BloggingContext _context;
        public BlogsController(BloggingContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = from x in _context.Blog select x;
            return View(blogs.ToArray());            
        }
    }
