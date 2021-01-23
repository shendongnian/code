    public ActionResult Index ( )
    {
        //...
        return View("View1");
    }
    
    [HttpPost]
    public ActionResult Index (HttpPostedFileBase file, string selectedOrgName, string selectedCatName)
    {
        //...
        ViewBag.orgcatJSON = "some json string"; 
        return View("View2");
    }
