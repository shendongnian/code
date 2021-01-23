    [RoutePrefix("at")]
    public class ATController : Controller
    {
        //GET /at/1/2
        [AllowAnonymous]
        [Route("{project}/{step}")]
        public ActionResult Index(int project, int step)
        {
            var m = new ATViewModel();
            m.Project = project;
            m.Step = step;
            return View(m);
        }
    
        //GET /at/1
        [AllowAnonymous]
        [Route("{project}")]
        public ActionResult Index(int project)
        {
            var v = RedirectToAction("Index", new { project = project, step = 99 });
            return v;
        }
    
        //GET /at
        [AllowAnonymous]
        [Route("")]
        public ActionResult Index()
        {
            var v = RedirectToAction("Index", new { project = 1, step = 99 });
            return v;
        }
    }
