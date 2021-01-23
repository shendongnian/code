    public class JsonWrapperAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            //Check it's JsonResult that we're dealing with
            JsonResult jsonRes = context.Result as JsonResult;
            if (jsonRes == null)
                return;
            jsonRes.Data = new { Object = new { Body = jsonRes.Data } }
        }
    }
