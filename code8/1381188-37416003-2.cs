    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MyCustomFilter : System.Web.Mvc.ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext context) {
            Debug.WriteLine("Process response");
            //From here you have access to the response to process what you need
            //eg: context.HttpContext.Response.Headers.Add("MyCustomHeaderName","value");
            base.OnActionExecuted(context);
        }
    }
