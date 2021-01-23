    [HttpGet]
    public ActionResult MyForm()
    {
        var model = new MyFormModel();
        [...]
        return View(model);
    }
    [HttpPost]
    public ActionResult MyForm(MyFormModel model)
    {
        if (model.AddStudent)
        {
            // do some add student logic
        }
        if (model.AddCourse)
        {
            // add course logic
        }
        if (model.Submit)
        {
            // perform save
            return RedirectToAction("SomewhereElse");
        }
        return View(model);
    }
