    public class ValidateCaptcha : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cookiePayload = actionContext.Request.GetCookie("MyCaptcha");
            var requester = actionContext.ActionArguments["requester"] as SampleRequester;
            if (requester != null && cookiePayload == requester.captcha)
                 return;
            var requester = actionContext.ActionArguments["requester"] as AnotherRequester;
            if (requester != null && cookiePayload == requester.captcha)
                 return;
    
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        }
    }
