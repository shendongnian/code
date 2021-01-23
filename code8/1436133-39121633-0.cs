    public class JsonWrapperAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            //Check it's JsonResult that we're dealing with
            JsonResult jsonRes = context.Result as JsonResult;
            if (jsonRes == null)
                return;
            //copy all properties and modify Data
            context.Result = new JsonResult
            {
                ContentEncoding = jsonRes.ContentEncoding,
                ContentType = jsonRes.ContentType,
                JsonRequestBehavior = jsonRes.JsonRequestBehavior,
                MaxJsonLength = jsonRes.MaxJsonLength,
                RecursionLimit = jsonRes.RecursionLimit,
                Data = new { Object = new { Body = jsonRes.Data } }
            };
        }
    }
