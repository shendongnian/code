       public class BaseController : Controller
        {
            public JsonResult JsonPublic(object data)
            {
                return Json(data);
            }
        }
    
    
        public static class ControllerExtensions
        {
            public static JsonResult AjaxRedirect(this BaseController cntrl, string action, object routeValues)
            {
                cntrl.JsonPublic() // accessible
            }
        }
