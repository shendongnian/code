    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new BloggingContext())
            {
                var blogs = from x in context.Blogs select x;
                return View(blogs.ToArray());
            }
        }
    }
