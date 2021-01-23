    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MyMethod(HttpContext);
            // Other code
        }
    }
    public void MyMethod(Microsoft.AspNetCore.Http.HttpContext context)
    {
        var host = $"{context.Request.Scheme}://{context.Request.Host}";
        // Other code
    }
