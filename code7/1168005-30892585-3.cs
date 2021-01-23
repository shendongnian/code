    [HttpPost]
    public ActionResult Create(PostCreateViewModel model)
    {
        model.Categories = GetCategories(); // call again, Categories don't persist in a POST.
        if (ModelState.IsValid)
        {
            var post = new Post();
            // ...
            post.Category = model.Categories.FirstOrDefault(x => x.CategoryId == model.SelectedCategoryId);
            // ...
        }
            
        return View(model);
    }
