    [HttpGet]
    public ActionResult AddCost()
    {
        var model = new Cost();
        return PartialView(model);
    }
    [HttpPost]
    public void AddCost(Cost model)
    {
        if (ModelState.IsValid) {
            db.SaveCost(model);...
        }
    }
