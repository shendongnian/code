    public ActionResult Create()
    {
         ViewModel model = new ViewModel();
    
         return View(model);
    }
    
    [HttpPost]
    public ActionResult Create(ViewModel model)
    {
         if (!ModelState.IsValid)
         {
             // If validation fails send the view model back to the view and fix any errors
             return View(model);
         }
         // Do what you need to do here if there are no validation errors
         // In your example we are posting back to the current view to
         // display the welcome message
         return View(model);
    }
