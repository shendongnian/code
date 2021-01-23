     public class HomeController:Controller
     {
       public ActionResult Index()
        {
         WCF.CommunicationServiceClient Client = new WCF.CommunicationClient("BasicHttpBinding_ICommunicationService");
         List<dynamic> objectlist = Client.GetList("_something_");
         return View("ShowView");
        }
     }
