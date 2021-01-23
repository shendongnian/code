    contentFileServer.StaticFileOptions.OnPrepareResponse = (context) => 
    {
        if (context.OwinContext.Authentication.User == null)
        {
            // Reply an unauthorized
            const string unauthorizedBody = "Unauthorized"; // or HTML or anything else
            ctx.OwinContext.Response.StatusCode = 401;
            ctx.OwinContext.Response.Headers.Set("Content-Length", unauthorizedBody.Length.ToString());
            ctx.OwinContext.Response.Headers.Set("Content-Type", "text/html");
            ctx.OwinContext.Response.Write(unauthorizedBody);
        }
    };
