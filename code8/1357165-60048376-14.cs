    using WeeklyReport.Repository;
    namespace WeeklyReport.Controllers
    {    
        public class ReportController : Controller
        {
            private readonly IDataRepository repository;
            public ReportController(IDataRepository repository)
            {
                this.repository = repository;
            }
            public ActionResult Index()
            {
                List<ReportViewModel> reportVM = new List<ReportViewModel>();
                var reqs = repository.GetAllMetrics();
                // iterate reqs and put into reportVM, etc.
                return View(reportVM);
            }
        }
    }
