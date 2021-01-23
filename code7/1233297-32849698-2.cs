    public class Version : Controller
    {
      public JsonResult Check() {
        return new Json((GetWebsiteVersionNumber() == GetDatabaseVersionNumber()));
      }
    }
