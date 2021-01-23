    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                var errors = actionContext.ModelState
                                          .Values
                                          .SelectMany(m => m.Errors
                                                            .Select(e => e.ErrorMessage));
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
                actionContext.Response.ReasonPhrase = string.Join("\n", errors);
            }
        }
    }
