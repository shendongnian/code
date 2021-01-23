    public class UxController : Controller
    {
         public ActionResult WithResponse(ActionResult result, string message)
         {
              PageResponse(message);
              return result;
         }
    
         protected void PageResponse(string message)
         {
              TempData["Ux_Response"] = message;
         }
    }
