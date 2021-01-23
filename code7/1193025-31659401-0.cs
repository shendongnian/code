    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddTeams()
        {
            // you do not need to pass anything if you list is empty
            return View();
        }
        [HttpPost]
        public ActionResult AddTeams(List<string> teamNames)
        {
            // do whatever you want with your teamnames
            return RedirectToAction("Index");
        }
    }
