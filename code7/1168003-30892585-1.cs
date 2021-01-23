    [HttpPost]
    public ActionResult Create(PostCreateViewModel model)
    {
        model.Categories = GetCategories(); // call again, Categories don't persist in a POST.
            
        // validation and other lines
            
        return View(model);
    }
