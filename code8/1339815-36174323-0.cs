    public ActionResult Index(int pageNumber, int pageSize, string filter, string sortColumn, 
                              string sortOrder)
    {
       int totalCount = ...
       return Json(totalCount);
    }
