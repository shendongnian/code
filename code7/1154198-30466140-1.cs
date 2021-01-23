    public class UserProfileController : Controller
    {
       [ChildActionOnly]
       public ActionResult GetPropertiesForUser()
       {
          // ...
         return PartialView(...);
       }
    }
