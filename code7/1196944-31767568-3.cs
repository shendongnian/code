        private ImageDBContext db = new ImageDBContext ();
        [HttpGet]
        public ActionResult Index()
        {
            var myList = db.Images.ToList();
            return View(myList);
        }
        [HttpPost]
        public ActionResult Index(string category)
        {
            var myList = db.Images.ToList();
            if (string.IsNullOrEmpty(category) || category == "All")
                return PartialView("_SearchResult", myList);
            if (!string.IsNullOrEmpty(category))
                myList = myList.Where(m => m.Category == category).ToList();
            return PartialView("_SearchResult", myList);
        }
