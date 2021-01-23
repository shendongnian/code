    public ActionResult Index(int id)
        {
    //if you want use in view you can save id in view bag
            ViewBag.ID = id;
            Your Code......
            return View(...);
        }
