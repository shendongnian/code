    public interface IServiceFactory {
        object GetService(string args);
    }
    public class MyController : Controller {
        IServiceFactory serviceFactory
        public MyController(IServiceFactory serviceFactory) {
            this.serviceFactory = serviceFactory;
        }
    
         // method under test
        public ActionResult DeleteFilter(string args) {
            try {
                var model = serviceFactory.GetService(args);
                return View(model);
            } catch(Exception ex) {
               return JsonActionResult(JsonReturnType.Error, ajaxMessage: "There was an error in deleting the filter.");
            }
        }         
    }
