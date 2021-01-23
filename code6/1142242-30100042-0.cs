    [OutputCache(Duration=10, VaryByParam="none")]
    public ActionResult GetPage()
    {
        //Do something
        return View();
    }
