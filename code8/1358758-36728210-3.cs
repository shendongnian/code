    public class ValidateCaptcha : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cookiePayload = actionContext.Request.GetCookie("MyCaptcha");
            dynamic requester = actionContext.ActionArguments["requester"];
            if (requester != null && cookiePayload == requester.captcha)
                 return;
    
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        }
    }
