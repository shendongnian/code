    [HttpPost]
    public ActionResult Create(PostCreateViewModel model)
    {
        model.Categories = GetCategories(); // call again, Categories don't persist in a POST.
        if (ModelState.IsValid)
        {
            var post = new Post();
            // ...
            post.Category = context.Categories.FirstOrDefault(x => x.CategoryId == model.SelectedCategoryId);
            // ...
            return RedirectToAction("Index");
        }
            
        return View(model);
    }
