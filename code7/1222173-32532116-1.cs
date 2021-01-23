    public override async Task Invoke(IOwinContext context)
    {
        context.Response.Headers.Add("Content-Length", <somelength>);
        await context.Response.WriteAsync("test");
    }
