    namespace WebApplication
    {
        public class HomeController : Controller
        {
            [NamespaceConstraint]
            public IActionResult Index()
            {
                return View();
            }
        }
    }
