    public ActionResult GetProduct(string product)
    {
        ProductViewModel model = new ProductViewModel();
        var products = model.GetProducts(product);
        return View(products);
    }
