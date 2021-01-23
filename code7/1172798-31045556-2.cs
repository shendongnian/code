    public ActionResult Create()
    {
         CreateViewModel model = new CreateViewModel();
         // Populate your customer attributes
    
         return View(model);
    }
