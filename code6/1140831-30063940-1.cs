    public class RequiresJsonBody : ActionFilterAttribute
    {
        private string paramName;
        public RequiresJsonBody (string paramName)
        {
            this.paramName = paramName;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            IDictionary<string, string> errors = new Dictionary<string, string>();
            // Validate incoming. Add key / error messages to dictionary...
            foreach (var err in errors)
            {
                actionContext.ModelState.AddModelError(err.Key, err.Value);
            }
            if (!actionContext.ModelState.IsValid
                && errors.Keys.Count > 0)
            {
                actionContext.Response
                    = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        String.Join(" ", errors.Values.ToArray()));
            }
        }
    }
