    public class BaseController : Controller
    {
    protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior) {
        return new CustomJsonResult{
            Data = data,
            ContentType = contentType,
            ContentEncoding = contentEncoding
        };
    }
    }
