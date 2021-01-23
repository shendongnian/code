    public class JobsController : Controller
    {
        [Route("jobs/workload/{workload}/jobtype/{jobtype?}")]
        [Route("jobs/workload/{workload?}")]
        [Route("jobs")]
        public ActionResult Index(string workload = "", string jobType = "")
        {
            return View();
        }
    }
