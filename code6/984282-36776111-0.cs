    public class InvalidAuthenticationMiddleware : OwinMiddleware
    {
        public InvalidAuthenticationMiddleware(OwinMiddleware next) : base(next) { }
        public override async Task Invoke(IOwinContext context)
        {
            context.Response.OnSendingHeaders(state =>
            {
                var response = (OwinResponse)state;
                if (!response.Headers.ContainsKey("AuthorizationResponse") && response.StatusCode != 400) return;
                response.Headers.Remove("AuthorizationResponse");
                response.StatusCode = 401;
            }, context.Response);
            await Next.Invoke(context);
        }
    }
