    public ActionResult Index ( )
    {
        //...
        return View("View1");
    }
    
    [HttpPost]
    public ActionResult Index (HttpPostedFileBase file, string selectedOrgName, string selectedCatName)
    {
        //...
        //let's pass the json directly to the View and make the dependency 100% clear
        var json = "some json string"; 
        return View("View2", json);
    }
