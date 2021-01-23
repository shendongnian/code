    [RoutePrefix("at")]
    public class ATController : Controller
    {
        //GET /at/5/step/6
        [Route("{project:int}/step/{step:int}")]
        public ActionResult Index(int project, int step) {
            var m = new ATViewModel();
            m.Project = project;
            m.Step = step;
            return View(m);
        }
    
        //GET /at/1
        [Route("{project:int}")]
        public ActionResult ProjectSuppliedNoStep(int project) {
            var p = project;
            var s = 33;   //fake lookup
            return RedirectToAction("Index", new { project = p, step = s });
        }
    
        //GET /at
        [Route("")]
        public ActionResult NoProjectNoStep() {
            var p = 7;  //fake lookup
            var s = 33;
            return RedirectToAction("Index", new { project = p, step = s });
        }
    }
