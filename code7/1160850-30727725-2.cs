    public ActionResult CostList() 
    {
        var model = db.loadCosts(); ...
        return PartialView(model);
    } 
