    [HttpPost]
    public ActionResult Index(string FNWtodo, string SearchInput)
    {
         // all code to load viewmodels to list
        return View(lstAccountVM);
    }
    public ActionResult Index()
    {
        return View();
    }
