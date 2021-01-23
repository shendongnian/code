    public async Task Invoke(HttpContext context)
    {
        var watch = new Stopwatch();
        context.Response.OnSendingHeaders(x =>
        {
            watch.Stop();
            context.Response.Headers.Add("X-Processing-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
        }, null);
        watch.Start();
        await _next(context);
        watch.Stop();
    }
    
