    public class OwinContextMiddleware : OwinMiddleware
    {
        public OwinContextMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
        public async override Task Invoke(IOwinContext context)
        {
            context.Environment.Add("Context", context);
            await Next.Invoke(context);
        }
    }
