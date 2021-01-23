    public class MyBaconActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Some code here
            base.OnResultExecuting(filterContext);            
        }
    }
