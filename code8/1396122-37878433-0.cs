    public ActionResult Search(HomeModel model)
    {
        if (model.Filter == null)
        {
            model.Filter = new OverviewFilterModel
            {
                Type1 = true,
                Type2 = true,
                WorkingOrder = ""
            };
        }
        ViewBag.Results = GetResults(model.Filter);
        return View("Index", new HomeModel { Filter = filter });
    }
