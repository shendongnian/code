    [HttpGet]
    public ActionResult VehicleDetail()
    {
        pageSessionSetup();
        return PartialView("VehicleDetail", main.Vehicle);
    }
    
    [HttpPost]
    [ActionName("VehicleDetail")]
    public ActionResult VehicleDetail(VehicleDetailDisplay model)
    {
        ModelState.AddModelError("", "Errors occured");
        main.Vehicle = model;
        pageSessionSetup();
        return PartialView("VehicleDetail", main.Vehicle);
    }
