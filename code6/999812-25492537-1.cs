     public class ClubOpeningToolController : Controller
    {
        //
        // GET: /ClubOpeningTool/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Club(int c = 0)
        {
            return View();
        }
    }
