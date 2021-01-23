    [ChildActionOnly]
    public ActionResult SomeForm()
    {
        var model = new SomeModelForForm();
        return PartialView("_SomeForm", model);
    }
