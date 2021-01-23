    public class UserProfileController : Controller
    {
       [ChildActionOnly]
       public async Task<ActionResult> GetPropertiesForUser()
       {
          // ...
         return PartialView(...);
       }
    }
