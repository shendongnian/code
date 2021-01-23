    [Area("Dashboard")]
    [Route("[area]/[controller]/[action]")]
    public class HomeController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
