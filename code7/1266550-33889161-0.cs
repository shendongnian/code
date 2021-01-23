    public ActionResult YourActionMethod(...)
    {
        var selectItems = Repository.SomeDomainModelObjectCollection
          .Select(x => new SelectListItem {
            Text = x.SomeProperty,
            Value = x.SomeOtherProperty,
            Selected = ShoudBeSelected(x)
        });
        ViewBag.SelectListItems = selectItems;
        // more code
        var model = ...; // create your model
        return View(model);
    }
