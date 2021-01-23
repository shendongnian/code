    [HttpPost]
    public ActionResult Create(PostCreateViewModel model)
    {
        model.Categories = GetCategories(); // call again, Categories don't persist in a POST.
        if (ModelState.IsValid)
        {
            var post = new Post();
            // From ViewModel
            post.Title = model.Title;
            post.DescText = model.DescText;
            post.Category = model.Categories.FirstOrDefault(x => x.CategoryId == model.SelectedCategoryId);
            // ....
        }
        // validation and other lines
            
        return View(model);
    }
