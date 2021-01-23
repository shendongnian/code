    public ActionResult GetProduct()
    {
        ProductViewModel model = new ProductViewModel();
        var products = model.GetProducts("Headphones");
        return View(products);
    }
