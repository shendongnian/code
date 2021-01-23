    public class BackgroundTaskController : Controller
    {
      [AllowAnonymous]
      [HttpPost]
      [CallbackAction]
      public ActionResult Callback(Guid callbackId, object state)
      {
        // Perform the background work
        // ... insert your background task code here ...
        
        // Return a status code back to the Revalee Service.
        return new HttpStatusCodeResult(HttpStatusCode.OK);
      }
    }
