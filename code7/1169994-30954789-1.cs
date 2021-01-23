        SystemManager _sm = new SystemManager();
    
     [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    
     [HttpPost]
        public ActionResult Index(MyModel context, string Name)
        {
            context = _sm.RetrieveChancesLeft(Name);
    
            if (context.Chances > 0)
            {
                return RedirectToAction("About", "Home");
            }
    
            else
            {
                return RedirectToAction("GetStarted", "Home");
            }
        }
