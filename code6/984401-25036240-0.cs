    public override Task Invoke(IOwinContext context)
    {
        if (Wacko.WhatDOuKnow)
        {
            context.Response.Redirect("/awesomeurl");
            return Task.FromResult<object>(null);
        }
        return Next.Invoke(context);
    }
