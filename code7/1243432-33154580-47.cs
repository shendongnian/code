    public ActionResult Index(ProductSearchModel searchModel)
    {
        var business = new ProductBusinessLogic();
        var model = business.GetProducts(searchModel);
        return View(model);
    }
