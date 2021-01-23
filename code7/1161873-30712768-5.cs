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
            int i = 0;
            do
            {
                hubContext.Clients.All.sendMessage("Uploading ", i * 10);
                Thread.Sleep(1000);
                i++;
            }
            while (i < 10);             
            return View("Index");
        }
    }
