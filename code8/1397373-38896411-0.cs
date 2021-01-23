    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            if (context.Response.StatusCode == (int) HttpStatusCode.OK &&
                context.Request.Path.Value.EndsWith(".map"))
            {
                context.Response.ContentType = "application/json";
            }
            return Task.CompletedTask;
        });
    
        await nextMiddleware.Invoke(context);
    }
