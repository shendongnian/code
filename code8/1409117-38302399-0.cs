    public ActionResult Index(int id)
    {
         ViewBag.Title = "My Title";
         return View(_db.Articles.Find(id));
    }
