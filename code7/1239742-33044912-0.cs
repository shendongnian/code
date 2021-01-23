    public ActionResult Index()
    {
        var products = db.ProductImages
                         .Include("Products")
                         .Select(a => new ProductDisplayViewModel {
                              ProductId = a.ProductID,
                              Name = a.Product.Name,
                              ImageUrl = a.URL
                         });
        return View(products );
    }
