    public class HomeController : Controller
        {
            private static System.Timers.Timer timer;
            public ActionResult Index()
            {
                timer = new System.Timers.Timer(10000);
                timer.Elapsed += new ElapsedEventHandler(saveUsers);
                timer.Interval = 3600000;
                timer.Enabled = true;
                return View();
            }
        }
