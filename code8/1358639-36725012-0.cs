    public ActionResult Index()
    {
        DataTable dtable = new DataTable();
        dtable = SQL.ExecuteSQLReturnDataTable(SQL.SelectUnitsQuery, CommandType.Text, null);
        ViewBag.Units = dtable;
        DataTable rpts = new DataTable();
        rpts = SQL.ExecuteSQLReturnDataTable("select ReportName from ReportsLU", CommandType.Text, null);
        ViewBag.Reports = rpts;
        return View();
    }
