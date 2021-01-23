    public class MyService: IMyServiceInterface { 
    //Code contract implementation here
    }
    public interface IMyServiceInterface { 
    //Code contract here
    }
    public class MyController: Controller {
          private readonly IMyServiceInterface service;
          public MyController(IMyServiceInterface service) { 
              //inject dependency
              this.service = service;
          }
          public ActionResult MyMethod() {
               //consume service here
               return View();
          }
    }
