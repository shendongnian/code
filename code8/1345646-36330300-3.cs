    private static log4net.ILog Log { get; set; }
      ILog log = log4net.LogManager.GetLogger(typeof(HomeController));      
    
            public ActionResult Index()
            {
                log.Debug("Debug message");
                log.Warn("Warn message");
                log.Error("Error message");
                log.Fatal("Fatal message");
                ViewBag.Title = "Home Page";
                return View();
            }
