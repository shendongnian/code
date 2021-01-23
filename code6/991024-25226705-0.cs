    [HttpPost]
    public ActionResult Create(Messsaging form)
    {
      if (!ModelState.IsValid)
      {
        return View(form); // returns the view with errors
      }
      // It OK so save
    }
