    [HttpPost]
    public ActionResult Index(TestModel model)
    {
        model.Number = model.Number  +1;
        ModelState.Clear();
        return View(model);
    }
