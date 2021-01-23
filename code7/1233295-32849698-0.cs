    public class Version : Controller
    {
      public JsonResult Check() {
        bool result = true;
        //do failure checks and if fail set result to false
        return new Json(result);
      }
    }
