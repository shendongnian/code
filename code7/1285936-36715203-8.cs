    namespace Exzen.Areas.Test.Controllers
    {
        [Area("Test")]    
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }
