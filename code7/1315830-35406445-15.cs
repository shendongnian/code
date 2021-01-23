    public ActionResult Edit(int? id)
    {
        var model = new ProductViewModel();
        model.Categories = dbContext.Categories.Select(x => new SelectListItem() {Text = x.Name, Value = x.Id.ToString()}).ToList();
        // check if product even exists
        model.EditableProduct = id.HasValue ? dbContext.Products.Find(id.Value) : new Product();
        return View(model);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Edit(ProductViewModel model)
    {
        // check validation
        Product product;
        if (model.EditableProduct.Id > 0)
            product = dbContext.Products.Find(model.EditableProduct.Id);
        else
        {
            product = new Product();
            dbContext.Products.Add(product);
        }
        product.CategoryId = model.EditableProduct.CategoryId;
        product.Name = model.EditableProduct.Name;
        // add try/catch 
        dbContext.SaveChanges();
        return RedirectToAction("Edit", new {id = product.Id});
    }
