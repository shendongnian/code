    public class InvalidQueryStringRejectorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var arguments = actionContext.ActionArguments.Keys;
            var queryString = actionContext.Request.GetQueryNameValuePairs()
                .Select(q => q.Key);
            var invalidParams = queryString.Where(k => !arguments.Contains(k));
            if (invalidParams.Any())
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    message = "Invalid query string parameters",
                    parameters = invalidParams
                });
            }
        }
    }
