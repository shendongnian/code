    public ActionResult EditSingles(EditSinglesVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model); // repopulate SelectList's
        return View(model(;
      }
      // Initialize a new data model
      // Map the view model properties to it
      // Save and redirect
    }
