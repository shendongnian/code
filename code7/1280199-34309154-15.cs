    namespace WebApplication.Controllers
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
