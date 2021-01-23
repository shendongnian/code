    public class BaseController : Controller
    {
      public BaseController()
      {
         CanFindLocationDatabaseContext db = new CanFindLocationDatabaseContext();
      }
    }
