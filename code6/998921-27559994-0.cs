    public class TestController:Controller
    {
      [HttpGet]
      public ActionResult MyView()
      {
        return PartialView("_MyView");
      }
    
    }
