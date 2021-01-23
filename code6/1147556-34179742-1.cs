    public class HomeController : Controller
    {
        IConfiguration config;
        public HomeController(IConfiguration config)
        {
            this.config = config;
        }
        public IActionResult Index()
        {
            var template = "<marquee>{0}</marquee>";
            var content = string.Format(template, config.Get("random"));
            return Content(content, "text/html");
        }
    }
