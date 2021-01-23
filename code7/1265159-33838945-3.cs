         public class MultiStepController : Controller
       {
        // GET: MultiStep
        public ActionResult Index()
        {
            return View(new MultiStepViewModel());
        }
        
        [HttpPost]
        public ActionResult PostMultiStepData(MultiStepViewModel model)
        {
            //your process logic
            if (success)
            {
                return View("It was successfull");
            }
            else
            {
                return RedirectToAction("Index", "MultiStep", model);
            }
        }
    }
