    public class FooFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (modelState != null && modelState.IsValid == false)
            {
                // this class takes the model state and parses 
                // it into a dictionary with all the errors
                var errorModel = new SerializableError(modelState);
                context.Result = new BadRequestObjectResult(errorModel);
            }
        }
    }
