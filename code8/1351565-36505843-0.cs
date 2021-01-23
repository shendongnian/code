    [HttpPost]
    public ActionResult Index(ProductViewModel product)
    {
        // ...
        return RedirectToAction("Index");
    }
