    public ActionResult Index()
        {
            var model = _db.Ramais.ToList();   
            return View(model);
        }
