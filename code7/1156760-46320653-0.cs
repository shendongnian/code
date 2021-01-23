    [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Name = "HttpGet";
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewBag.Name = "HttpPost";
            return RedirectToAction("Index");
        }
