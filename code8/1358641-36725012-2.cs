    public class YourModel {
        public DataTable dt1 { get; set; }
        public DataTable dt2 { get; set; }
        public DataTable dt3 { get; set; }
        // Other properties
    }
    public ActionResult Index()
    {
        YourModel model = new YourModel();
        
        DataTable dtable = new DataTable();
        dtable = SQL.ExecuteSQLReturnDataTable(SQL.SelectUnitsQuery, CommandType.Text, null);
        model.dt1 = dtable;
        DataTable rpts = new DataTable();
        rpts = SQL.ExecuteSQLReturnDataTable("select ReportName from ReportsLU", CommandType.Text, null);
        model.dt2 = rpts;
        return View(model);
    }
