    public ActionResult Create(ProjectVM model)
    {
        if (!ModelState.IsValid)
        {
            model.CategoryList = new SelectList(db.Categories, "ID", "Name"); // add this
            return View(model);
        }
        // Save and redirect
    }
