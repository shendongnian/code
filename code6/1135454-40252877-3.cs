        public ActionResult Index()
        {
            var names = XFile.GetFileInformation();
            return View(names);
        }
