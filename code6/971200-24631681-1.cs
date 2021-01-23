    public ActionResult Index(string actionType)
    {
        LayoutModel Model = new LayoutModel();
        return View(actionType, model);
    }
