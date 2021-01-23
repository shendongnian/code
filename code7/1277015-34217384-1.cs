    [HttpPost]
    public ActionResult InsertData(ViewModel model)
    {
        ModelState.Clear();
        model = new ViewModel();
    
        return View(model);
    }
