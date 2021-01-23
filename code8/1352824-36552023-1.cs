    [HttpPost]
    public ActionResult Index(IndexViewModel model)
    {
        var selectedNumber= model.SelectedEmployeeId; 
        return View();
    }
