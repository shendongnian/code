    public ActionResult Details()
    {
        var model = new DetailsVM();
        model.Salary = 1400 / 0.2;
        return View(model);
    }
