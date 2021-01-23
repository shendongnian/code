    public ActionResult Index()
    {
        if(User.IsInRole("admin"))
        {
           return RedirectToAction("Index", "GlobalAdmin");
        }
        return View();
    }
