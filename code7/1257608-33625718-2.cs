    public ActionResult Create()
    {
        var model = new Products();
        model.CategoryList = db.Categories.Select(x => new SelectListItem
        {
            Text = x.CategoryName,
            Value = x.CategoryName
        }).ToList();
        return View(model);
    }
    
