    public class ProgressController : Controller
    {
        // GET: Progress
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoTest()
        {
            // Initialize Hub context
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            hubContext.Clients.All.sendMessage("Initalizing...", 0);
            for (int i = 0; i < 11; i++)
            {
                hubContext.Clients.All.sendMessage("Uploading ", i*10);
                Thread.Sleep(1000);
            }             
            return View("Index");
        }
    }
