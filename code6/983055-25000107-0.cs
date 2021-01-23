    public class FixContentTypeHeader : OwinMiddleware
    {
        public FixContentTypeHeader(OwinMiddleware next) : base(next) { }
    
        public override async Task Invoke(IOwinContext context)
        {
            // Check here as requests can or cannot have Content-Type header
            if(!string.IsNullOrWhiteSpace(context.Request.ContentType))
            {
                MediaTypeHeaderValue contentType;
    
                if(!MediaTypeHeaderValue.TryParse(context.Request.ContentType, out contentType))
                {
                    context.Request.ContentType = context.Request.ContentType.TrimEnd(';');
                }
            }
    
            await Next.Invoke(context);
        }
    }
----
    public void Configuration(IAppBuilder appBuilder)
    {
        appBuilder.Use<FixContentTypeHeader>();
