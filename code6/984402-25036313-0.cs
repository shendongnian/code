    public class BetterOrNotMiddleware : OwinMiddleware
    {
        public override Task Invoke(IOwinContext context)
        {
            if (Wacko.WhatDOuKnow)
            {
                context.Response.Redirect("/awesomeurl");
                // fast path
                return Task.FromResult<object>(null);
            }
            else
            {
                return Next.Invoke(context);
            }
        }
        public BetterOrNotMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
    }
