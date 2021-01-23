    public ActionResult Details(int sourceId, int targetId)
    {
        var viewModel = new DetailsViewModel();
        viewModel.TargetItem  = db.ConfigurationItemSet.Find(targetId);
        viewModel.SourceItem = db.ConfigurationItemSet.Find(sourceId);
        return View(viewModel);
    }
