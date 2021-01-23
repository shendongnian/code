    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(SocialViewModels model)
    {
      if (!ModelState.IsValid)
      {
        // repopulate your select lists
        return View(model);
      }
      // Get your data models, map the view model properties it
      // Save and redirect
    }
