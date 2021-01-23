    app.Use(async (context, next) =>
    {
        await next(context);
        context.Response // will have the response as processed by all the previous middleswares like mvc.
        if IsMinifiable(context.Response)
        MinifyResponse(context.Response);
        
    });
