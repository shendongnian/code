        public ActionResult Index()
        {
             var societylist = db.Societies.Include(x => x.TABLENAME);
             return View(societylist.ToList());
        }
