    [HttpPost]
    public ActionResult Index(CaseViewModel model)
    {
         // Check form validation
         if (!ModelState.IsValid)
         {
              // If validation fails, rebind the lists and send the current view model back
              model.Statuses = new List<Status>();
              model.Statuses.Add(new Status { Id = 1, Name = "Down" });
              model.Statuses.Add(new Status { Id = 2, Name = "Up" });
    
              model.Apps = new List<App>();
              model.Apps.Add(new App { Id = 1, Name = "SAP" });
              model.Apps.Add(new App { Id = 2, Name = "JAP" });
    
              return View(model);
         }
    
         // Form validation succeeds, do whatever you need to do here
         return RedirectToAction("Index");
    }
