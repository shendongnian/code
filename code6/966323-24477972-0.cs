    [HttpGet]
    public ActionResult EditItem(int id)
    {
        var myViewModel = new EditItemItemViewModel() { Id = id }; 
        return View(myViewModel);
    }
