    public class WebApiValidationAttribute : ActionFilterAttribute
    {
        public WebApiValidationAttribute(IValidatorFactory factory)
        {
            _factory = factory;
        }
    
        IValidatorFactory _factory;
    
        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.ActionArguments.Count > 0)
            {
                var allErrors = new Dictionary<string, object>();
    
                foreach (var arg in actionContext.ActionArguments)
                {
                    // skip null values
                    if (arg.Value == null)
                        continue;
    
                    var validator = _factory.GetValidator(arg.Value.GetType());
    
                    // skip objects with no validators
                    if (validator == null)
                        continue;
                        
                    // validate
                    var result = await validator.ValidateAsync(arg.Value);
    
                    // if there are errors, copy to the response dictonary
                    if (!result.IsValid)
                    {
                        var dict = new Dictionary<string, string>();
    
                        foreach (var e in result.Errors)
                            dict[e.PropertyName] = e.ErrorMessage;
    
                        allErrors.Add(arg.Key, dict);
                    }
                }
    
                // if any errors were found, set the response
                if (allErrors.Count > 0)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, allErrors);
                    actionContext.Response.ReasonPhrase = "Validation Error";
                }
            }
        }
    }
