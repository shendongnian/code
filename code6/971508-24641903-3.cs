    [HttpPost]
    public ActionResult Index(ViewModel model)
    {
        model.Data = DataJoin.Connector.data;
        return View(model);
    }
