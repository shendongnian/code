    public class ExampleController : ServiceStackController
    {
       public IMyType MyType {get;set;}
	   public ActionResult Index(){
	      return View();
       }
    }
