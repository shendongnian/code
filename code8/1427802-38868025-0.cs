    [ChildActionOnly]
    public ActionResult Categories
    {
        var model = new HomeViewModel()
        {
            .... // initialize properties
        }
        return PartialView("_CategoryViewModel", model)
    }
