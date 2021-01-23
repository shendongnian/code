    app.Use(async (context, next) =>
    {
        if (context.Request.Path.ToString().Equals("/sse"))
        {
            var response = context.Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            for(var i = 0; true; ++i)
            {
                // WriteAsync requires `using Microsoft.AspNetCore.Http`
                await response
                    .WriteAsync($"data: Middleware {i} at {DateTime.Now}\r\r");
                    
                await response.Body.FlushAsync();
                await Task.Delay(5 * 1000);
            }
        }
        await next.Invoke();
    });
