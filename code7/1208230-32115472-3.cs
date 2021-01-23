    public class AppController : BaseController
    {
    public ActionResult MyAction()
    {
      //Assuming there's a variable called data
    return Json(data,JsonBehavior.AllowGet);
    }
    }
