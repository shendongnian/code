    public class HomeController:Controller
    {
     public ActionResult Index()
     {
      WCF.CommunicationServiceClient Client = new WCF.CommunicationClient("BasicHttpBinding_ICommunicationService");
      List<MyClass> objectlist = Client.GetList("_something_");
    
      return View("ShowView", objectlist);
     }
    }
