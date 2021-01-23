    [NonAction]
    public virtual ViewResult View(string viewName, object model)
    {
        // Do not override ViewData.Model unless passed a non-null value.
        if (model != null)
        {
            ViewData.Model = model;
        }
        return new ViewResult()
        {
            ViewName = viewName,
            ViewData = ViewData,
            TempData = TempData
        };
    }
