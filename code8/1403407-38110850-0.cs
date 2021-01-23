    public ActionResult Customer()
    {
        return View("_Customer", db.Customer);
    }
    public ActionResult Invoice()
    {
        return View("_Invoice", db.Invoice);
    }
    public ActionResult Dealer()
    {
        return View("_Dealer", db.Dealer);
    }
    public ActionResult Paid()
    {
        return View("_Paid", db.Paid);
    }
    public ActionResult Products()
    {
        return View("_Products", db.Products);
    }
