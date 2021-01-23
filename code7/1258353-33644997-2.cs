    [HttpGet]
    public ActionResult ProductFields_Create()
    {
        var model = new ProductFields
        {
            LisGroups = db.UserGroup.ToList();
        };
        return View(model);
    }
