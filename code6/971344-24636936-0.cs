    [ChildActionOnly]
    public ActionResult Something()
    {
        // retrieve a model, either by instantiating a class, querying a database, etc.
        return PartialView(model);
    }
