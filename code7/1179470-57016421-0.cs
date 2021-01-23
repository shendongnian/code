services.AddHttpContextAccessor();
In Controller
public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _context;
        public HomeController(IHttpContextAccessor context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
           var context = _context.HttpContext.Request.Headers.ToList();
           return View();
        }
   }
