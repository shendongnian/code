    public class DefaultController : Controller
    {
        // GET: Sync
        public ActionResult Index()
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            DoTask();
            myStopwatch.Stop();
            ViewBag.Message = ($"Process took {myStopwatch.Elapsed.TotalSeconds.ToString()}");
            return View("Index");
        }
        // GET: Async
        public ActionResult IndexAsync()
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            Task.Factory.StartNew(DoTaskAsync);
            myStopwatch.Stop();
            ViewBag.Message = ($"Process took {myStopwatch.Elapsed.TotalSeconds.ToString()}");
            return View("Index");
        }
        // "the Sync Task"
        private void DoTask()
        {
            System.Diagnostics.Debug.Print($"DoTask Started at {DateTime.Now.ToString()}");
            System.Threading.Thread.Sleep(5000);
            System.Diagnostics.Debug.Print($"DoTask Finished at {DateTime.Now.ToString()}");
        }
        // "the Async Task"
        private async Task DoTaskAsync()
        {
            System.Diagnostics.Debug.Print($"DoTaskAsync Started at {DateTime.Now.ToString()}");
            System.Threading.Thread.Sleep(5000);
            System.Diagnostics.Debug.Print($"DoTaskAsync Finished at {DateTime.Now.ToString()}");
        }      
    }
