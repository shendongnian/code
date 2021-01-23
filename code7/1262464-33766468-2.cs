    public ActionResult ChartTable([DataSourceRequest]DataSourceRequest request)
    {
        var result = _dashRepo.GetCompsSnapshotVM().ToDataSourceResult(request);
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
    
    public ActionResult Dashboard()
    {
        return View();
    }
