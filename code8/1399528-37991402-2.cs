    [HttpPost]
    public ActionResult Edit(MyViewModel model)
    {
        bool isTypeValid = model.IsFoo || model.IsBar || model.IsMeh;
        if (!isTypeValid)
        {
            // add a ModelState error and return the view
        }
        Services myEnumValue = model.IsFoo ? Services.Foo : 0;
        myEnumValue |= model.IsBar ? Services.Bar : 0;
        myEnumValue  |= model.IsMeh ? Services.Meh : 0;
        // map the view model to an instance of the data model, save and redirect
