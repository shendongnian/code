    namespace WebApplication3.Areas.Users.Controllers
    {
        public class UserController : Controller
        {
            // GET: Users/User
            public ActionResult Index()
            {
                return View();
            }
            [HttpGet]
            public ActionResult Choose(int? userId, int? locationId)
            {
                return View();
            }
        }
    }
