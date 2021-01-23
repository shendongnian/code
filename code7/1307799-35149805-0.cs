    public ActionResult Index(int? catId)
    {
        // TODO: check catId for null
        List<ProductlistModel> products = pr.GetProductList(catId.Value);
        return View(products);
    }
