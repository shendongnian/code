    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
                //handle request logging
 
                await Next.Invoke(context); 
                //handle response logging
        }
    }
