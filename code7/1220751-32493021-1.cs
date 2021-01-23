        public ActionResult Index()
        {
            var _db = new ApplicationDbContext();
            var model = _db.People.Include("FilePaths").ToList();
            return View(model);
        }
