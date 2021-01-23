    public ActionResult Index()
    {
        // here we instantiate the type and supply it to the view. 
        ViewData.Model = new ProfileImages();
        return View();
    }
