    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            var address = HttpContext.Connection.RemoteIpAddress; // Request.UserHostAddress
            var userAgent = Request.Headers["User-Agent"].FirstOrDefault(); // Request.UserAgent
            return View();
        }
    }
