    [ServiceFilter(typeof(EnsureUserLoggedIn))]
    [Route("api/issues")]
    public class IssueController : Controller {
        // GET: api/issues
        [HttpGet]
        [ServiceFilter(typeof(EnsureUserLoggedIn))]
        public IEnumerable<string> Get(){...}
    }
