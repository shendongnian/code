    public class HomeController : Controller
    {
        //20160719 JPC access hosting environment via controller constructors
        private IHostingEnvironment _env;
    
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }
    
        public IActionResult Index()
        {
            string contentRootPath = _env.ContentRootPath;
            return View();
        }
