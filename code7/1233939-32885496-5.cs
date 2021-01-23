    public ActionResult Index()
    {
        var tenantName = "Get tenant based on your strategy";
        var db= DbHelper.GetDbContext(tenantName)
        var model= db.Products.ToList();
        return View(model);
    }
