    public ActionResult SearchResults(yourViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      // save and redirect
