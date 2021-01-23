    [RoutePrefix("Sample")]
    public class SampleController : Controller {
        //eg GET Sample/a/b
        [HttpGet]
        [Route("{user}/{id}")]
        public void ViewData(string user, string id) { ... }
        
        //eg POST Sample/a/b
        [HttpPost]
        [Route("{user}/{id}")]
        public void SetData(string user, string id) { ... }
    }
