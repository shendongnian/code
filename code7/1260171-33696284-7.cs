    public class ServerController : Controller
    {
       public JsonResult GetMyName()
       {
           ServerModel model = new ServerModel();
           var name = model.GetMyName;
           return Json(name, JsonRequestBehavior.AllowGet);
       }
    }
