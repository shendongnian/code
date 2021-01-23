    [Area("Dashboard")]
    [Route("[area]/[controller]")]
    public class HomeController : Controller
    {
        // GET: Dashboard
        [HttpGet("Index")]
        public ActionResult Index()
        {
            return View();
        }
