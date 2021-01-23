    public class ValidateCaptcha : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cookiePayload = actionContext.Request.GetCookie("MyCaptcha");
            Form form = (Form)actionContext.ActionArguments["requester"];
            if(cookiePayload != form.captcha)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
    }
