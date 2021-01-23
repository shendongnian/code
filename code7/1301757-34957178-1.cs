    public class SerializedOutputCacheAttribute : OutputCacheAttribute
    {
        private readonly object lockObject = new object();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Monitor.Enter(this.lockObject);
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Monitor.Exit(this.lockObject);
        }
    }
