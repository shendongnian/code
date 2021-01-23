    public class HelloWorldViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default", "Hello World.");
        }     
    }
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return ViewComponent("HelloWorld");
        }
    }
