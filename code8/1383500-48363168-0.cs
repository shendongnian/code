        // GET: Admin/Colors
        public ActionResult Index()
        {
            var colors = db.Colors.OrderBy(a => a.HexCode);
            return View(colors);
        }
