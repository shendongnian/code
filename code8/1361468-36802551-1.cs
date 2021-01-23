    public class MyController : Controller
    {
        private readonly IPersonReportGenerator _personReportGenerator;
        public MyController(IPersonReportGenerator personReportGenerator)
        {
            _personReportGenerator = personReportGenerator;
        }
    }
    public ActionResult GetReport(int personId)
    {
        var report = _personReportGenerator.Builder();
        return new ReportResult(report);
    }
