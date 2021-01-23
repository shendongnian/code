    public ActionResult Create()
    {
        ViewBag.Product_ID = new SelectList(db.Product, "ID", "Product");
    }
    [HttpPost]
    public ActionResult Create([Bind(Include = "ID, Product_ID" /*etc*/)] ActiveProducts activeProducts)
    {
        ViewBag.Product_ID = new SelectList(db.Product, "ID", "Product", activeProducts.Product_ID);
    }
