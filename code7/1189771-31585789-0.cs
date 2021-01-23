    public class GetMethodMiddleware : OwinMiddleware
    {
        public GetMethodMiddleware(OwinMiddleware next) :
            base(next)
        { }
        public override async Task Invoke(IOwinContext context)
        {
            var logger = ObjectFactoryHost.ObjectFactory.GetObject<ILogger>();
            var requestMethod = (string)context.Request.Environment["owin.RequestMethod"];
            var requestQueryString = (string)context.Request.Environment["owin.RequestQueryString"];
            var requestPathString = (string)context.Request.Environment["owin.RequestPath"];
            logger.Info(string.Format("{0}:{1}:{2}", requestMethod, requestQueryString,requestPathString));
            await Next.Invoke(context);
        }
    }
