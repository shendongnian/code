    public class ForegroundController : Controller
    {
      public ActionResult InitiateBackgroundTask()
      {
        // The absolute URL that will be requested on the callback.
        var callbackUri = new Uri("http://localhost/BackgroundTask/Callback");
      
        // The information that will be needed to initiate the background task.
        object state = "Any object";
    
        this.CallbackNowAsync(callbackUri, state)
  
        // ... your controller will now return a response to the browser
        return View();
      }
    }
