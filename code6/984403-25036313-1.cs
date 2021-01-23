    public class BetterOrNotMiddleware : OwinMiddleware
    {
        private static readonly Task CompletedTask = Task.FromResult<object>(null);
        public override Task Invoke(IOwinContext context)
        {
            if (Wacko.WhatDOuKnow)
            {
                context.Response.Redirect("/awesomeurl");
                // fast path
                return CompletedTask;
            }
            else
            {
                return Next.Invoke(context);
            }
        }
        // ...
    }
