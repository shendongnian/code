    public ActionResult Index()
    {
        IEnumerable <PieModel> pieModel = DAL.StatisticsAccess.getTypesForStatistics();
        return View(pieModel);      
    }
    [HttpPost]
    public ActionResult displayChart() // no longer used
    {
        var results = Json(DAL.StatisticsAccess.getTypesForStatistics()); 
        return Json(results);
    }
