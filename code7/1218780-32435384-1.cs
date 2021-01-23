    public class MyMiddleware
    {
        private readonly RequestDelegate _test;
    
        public MyMiddleware(RequestDelegate test)
        {
            _test = test;
        }
    
        public async Task Invoke(HttpContext context)
        {   
            return _test.Invoke(context);
        }
    }
