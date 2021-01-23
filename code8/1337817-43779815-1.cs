    public class MyFilterAttribute : TypeFilterAttribute
    {        
        public MyFilterAttribute() : base(typeof (MyFilterAttributeImpl))
        {
        }
        private class MyFilterAttributeImpl : IActionFilter
        {
            private MyService _sv;
            public MyFilterAttributeImpl(MyService sv)
            {
                _sv = sv;
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                // using the service here
				_sv.MyServiceMethod();
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                
            }
        }
    }
