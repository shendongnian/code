    public ActionResult View2(string value)
    {
        // ......
        ViewBag.StorageItem = value;
        return View();
    }
