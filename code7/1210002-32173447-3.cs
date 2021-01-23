    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(BookingVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureCreateModel(model);
        return View(model);
      }
      // map you view model properties to a new instance of your data model
      // save the data model and redirect.
    }
