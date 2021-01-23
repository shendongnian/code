    public ActionResult Error()
    {
     return View("Err");
    }
    public ActionResult Index()
    {
    ...
    
    return RedirectToAction("Error");
    }
    
    public ActionResult Create ()
    {
    ...
    
    return RedirectToAction("Error");
    }
