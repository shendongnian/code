    public class HomeController : Controller
    {
        private readonly IDbContext _context;
        public HomeController(IDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var data = _context.GetData();
            return View(data);
        }
    }
