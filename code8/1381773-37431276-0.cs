    [HttpPost]
    public ActionResult MyAction(FormVM model) 
    {
        if (!(model.Property1 || model.Property2 || model.Property3))
        {
            ModelState.AddModelError(nameof(model.Property1), "You must select at least one");
        }
        if (ModelState.IsValid) 
        {
            // Do something
        }
        return View(model);
    }
