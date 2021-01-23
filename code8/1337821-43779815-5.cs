    public class MyFilterAttribute : TypeFilterAttribute
    {        
        public MyFilterAttribute() : base(typeof (MyFilterAttributeImpl))
        {
        }
        private class MyFilterAttributeImpl : IActionFilter
        {
            private readonly MyService _sv;
            public MyFilterAttributeImpl(MyService sv)
            {
                _sv = sv;
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {                
				_sv.MyServiceMethod1();
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                _sv.MyServiceMethod2();
            }
        }
    }
