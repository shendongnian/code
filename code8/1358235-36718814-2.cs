    app.Use(async (c, n) =>
    {
        var request = c.Request;
    
        if (request != null)
        {
            string[] headerValues;
            if (request.Headers.TryGetValue("Content-Length", out headerValues))
            {
                var lengthValue = headerValues.First();
                if (Convert.ToInt64(lengthValue) > 1024 * 1024 * 20)
                {
                    c.Response.StatusCode = (int)HttpStatusCode.RequestEntityTooLarge;
                    return;
                }
            }
        }
    
        await n.Invoke();
    });
    //app.UseWebApi(..)
