    // your GET action
    public ActionResult Register()
    {
        var model = new RegisterModel();
        model.Regions = new SelectList(_database.Department, "Id", "Name", model.Region);
    
        return View(model);
    }
