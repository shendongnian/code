    public class ServerController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServerJoin sj)
        {
            Validate(sj); // adds the ModelStateErrors
            if (!ModelState.IsValid)
            {
                return View(sj);
            }
            ....
        }
    }
    public class VMController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMJoin vmj)
        {
            Validate(vmj); // adds the ModelStateErrors
            if (!ModelState.IsValid)
            {
                return View(vmj);
            }
            ....
        }
    }
    
