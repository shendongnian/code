    public class KestrelAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public KestrelAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var existingPrincipal = context.Features.Get<IHttpAuthenticationFeature>()?.User;
            var handler = new KestrelAuthHandler(context, existingPrincipal);
            AttachAuthenticationHandler(handler);
            try
            {
                await _next(context);
            }
            finally
            {
                DetachAuthenticationhandler(handler);
            }
        }
        private void AttachAuthenticationHandler(KestrelAuthHandler handler)
        {
            var auth = handler.HttpContext.Features.Get<IHttpAuthenticationFeature>();
            if (auth == null)
            {
                auth = new HttpAuthenticationFeature();
                handler.HttpContext.Features.Set(auth);
            }
            handler.PriorHandler = auth.Handler;
            auth.Handler = handler;
        }
        private void DetachAuthenticationhandler(KestrelAuthHandler handler)
        {
            var auth = handler.HttpContext.Features.Get<IHttpAuthenticationFeature>();
            if (auth != null)
            {
                auth.Handler = handler.PriorHandler;
            }
        }
    }
