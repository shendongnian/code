    namespace Exzen.Areas.Main.Controllers
    {
        [Area("Main")]    
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }
   
