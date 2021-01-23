    [HttpPost]
    public ActionResult Index(string searchTerm)
    {
        //handle your search stuff here...
        return RedirectToAction("Results", "Home");
    }
