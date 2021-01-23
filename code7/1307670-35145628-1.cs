    public class HomeController : Controller
        {
            [Route("MVC6")]
            [Route("")]
            public IActionResult Index()
            {
                return View();
            }    
        }
