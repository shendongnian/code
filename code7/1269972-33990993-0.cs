    public class BookingController : Controller
    {
       public ActionResult Process()
       {
           var vm = new ProcessViewModel();
           //set some properties on vm as needed
           return View(vm);
       }
       [HttpPost]
       public ActionResult Process(ProcessViewModel model)
       {
          // to do : Save and redirect        
       }
    }
    public class QuoteController : Controller
    {
       public ActionResult Process()
       {
          var vm = new ProcessViewModel();
           //set some properties on vm as needed
          return View(vm);
       }
       [HttpPost]
       public ActionResult Process(ProcessViewModel model)
       {
          // to do : Save and redirect
       }
    }
