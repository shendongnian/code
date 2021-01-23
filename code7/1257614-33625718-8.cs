    [HttpPost]
    public ActionResult Create(Product product)
    {
        if(ModelState.IsValid)
        {
            // Code here
        }
        product.CategoryList = db.Categories.Select(x => new SelectListItem
        {
            Text = x.CategoryName,
            Value = x.CategoryName
        }).ToList();
        return View(product);
    }
    
