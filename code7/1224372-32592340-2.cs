    public ActionResult Index()
    {
        var x = db.People.Include("ServiceNeeded").ToList();
        return View(x);
    }
