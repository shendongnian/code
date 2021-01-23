    public ActionResult Publication(int id)
    {
        string est = ...;
        // TempData.EST_ID = est;   // pass with TempData
        // or use routeValues passed as query string params
        return RedirectToAction("Create", "EP", routeValues: new { est = est });
    }
    public ActionResult Create(string est)
    {
        ViewBag.EST_ID = est;
        // or if set previously
        //   ViewBag.EST_ID = TempData.EST_ID;
        return View();
    }
