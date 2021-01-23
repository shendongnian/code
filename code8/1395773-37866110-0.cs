    public abstract class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new MySpecialJsonResult //Inherits from JsonResult and contains the desired serializer implementation
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
    public class EmployeeController : BaseController
    {
        public JsonResult Index()
        {
            //Your custom serializer will be used...
            return Json(new{Text="Hello"},JsonRequestBehavior.AllowGet);
        }
    }
