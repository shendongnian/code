     public class HomeController : Controller
        {
            private readonly Itest _config;
            public HomeController(Itest config)
            {
                _config = config;
            }
            public IActionResult Index()
            {
                var a = _config.AppSettings.Value.AppVersion;
                return View();
            }
        }
