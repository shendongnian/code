    [HttpPost]
    public ActionResult Read()
    {
        DataTable chartData = GetChartData();
        return Json(chartData, JsonRequestBehavior.DenyGet);
    }
