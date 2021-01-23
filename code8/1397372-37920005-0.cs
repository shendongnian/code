    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting((state) =>
        {
            if (context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
               if (context.Request.Path.Value.EndsWith(".map"))
               {
                 context.Response.ContentType = "application/json";
               }
            }          
            return Task.FromResult(0);
        }, null);
        await nextMiddleware.Invoke(context);
    }
