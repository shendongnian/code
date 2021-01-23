    public ActionResult Index()
    {
         ViewBag.Sites = db.Sites.ToList();
         return View(db.User_Role.ToList());
    }
