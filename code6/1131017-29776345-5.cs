    public class HomeController : Controller
    {
       IMyDataAccess dao;
       public HomeController(IMyDataAccess myDataAccess)
       {
         this.dao=myDataAccess;
       }
       public ActionResult MyAction(string userValue)
       {
          User user=this.dao.GetUser();
          //return something to the view as needed.
       }
    }
