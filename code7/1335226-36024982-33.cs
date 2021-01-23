    public class HomeController : Controller
    {
        public IActionResult GetHelloWorld()
        {
            return ViewComponent("HelloWorld");
        }
    }
