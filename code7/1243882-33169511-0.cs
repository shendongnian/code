    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ChangeFormatterAttribute : ActionFilterAttribute
    {
        private IEnumerable<MediaTypeFormatter> oldFormatters;
        private MediaTypeFormatter desiredFormatter;
    
        public ChangeFormatterAttribute(Type formatterType)
        {
            this.desiredFormatter = Activator.CreateInstance(formatterType) as MediaTypeFormatter;
        }
    
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var formatters = actionContext.ControllerContext.Configuration.Formatters;
    
            oldFormatters = formatters.ToList();
    
            formatters.Clear();
            formatters.Add(desiredFormatter);
    
            base.OnActionExecuting(actionContext);
        }
    
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var formatters = actionExecutedContext.ActionContext.ControllerContext.Configuration.Formatters;
    
            formatters.Clear();
            formatters.AddRange(oldFormatters);
    
            base.OnActionExecuted(actionExecutedContext);
        }
    }
