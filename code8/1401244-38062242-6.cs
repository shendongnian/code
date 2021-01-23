    public class PerformanceController : Controller
    {
        static PerformanceCounter ramCounter;
        static PerformanceCounter cpuCounter;
    
        static Timer timer;
        static ManualResetEvent waiter = new ManualResetEvent(false);
    
        static Performance lastMeasure = new Performance(); // the Model (in Mvc)
    
        static PerformanceController()
        {
            // Get the current process
            using (var p = Process.GetCurrentProcess())
            {
                ramCounter = new PerformanceCounter("Process", "Working Set", p.ProcessName);
                cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
            }
            // make sure some time has passed before first NextValue call
            timer = new Timer(s =>
            {
                waiter.Set();
            }, null, 500, Timeout.Infinite);
    
            // clean-up
            AppDomain.CurrentDomain.DomainUnload += (s, e) => {
                var time = (IDisposable)timer;
                if (time != null) time.Dispose();
                var wait = (IDisposable)waiter;
                if (wait != null) wait.Dispose();
                var rc = (IDisposable)ramCounter;
                if (rc != null) rc.Dispose();
                var cc = (IDisposable)cpuCounter;
                if (cc != null) cc.Dispose();
            };
        }
    
        private static  Performance GetReading()
        {
            // wait for the first reading 
            waiter.WaitOne();
            // maybe cache its values for a few seconds
            lastMeasure.Cpu = cpuCounter.NextValue();
            lastMeasure.Ram = ramCounter.NextValue();
            return lastMeasure;
        }
    
        //
        // GET: /Performance/
        public ActionResult Index()
        {
            return View(GetReading());
        }
    }
