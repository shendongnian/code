    [HttpPost]
    public ActionResult Create(PostCreateViewModel model)
    {
        model.Categories = GetCategories(); // call again, Categories don't persist in a POST.
        if (ModelState.IsValid)
        {
            var post = new Post();
            // ...
            var dbCategories = new DbCategories();
            post.Category = dbCategories.GetCategories().FirstOrDefault(x => x.CategoryId == model.SelectedCategoryId);
            // ...
        }
            
        return View(model);
    }
