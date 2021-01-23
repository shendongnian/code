    public ActionResult Foo()
    {
        ...
        PopulateSelectLists(model);
        return View(model);
    }
    [HttpPost]
    public ActionResult Foo(FooViewModel model)
    {
        ...
        PopulateSelectLists(model);
        return View(model);
    }
    private void PopulateSelectLists(FooViewModel model)
    {
        // set select list properties
    }
