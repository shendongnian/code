    public override void OnException(HttpActionExecutedContext ctx)
    {
        log.Error(ctx.Exception.Message, ctx.Exception);
        var ex = ctx.Exception as HttpResponseException;
        if(ex.IsNotNull() && ex.Response.IsNotNull())
        {
            ctx.Response = ApiResponseFactory.CreateErrorResponse(ex.Response.StatusCode
                       , ex.Response.ReasonPhrase, ex.Message);
        }
        else
        {
            ctx.Response = ApiResponseFactory.CreateErrorResponse(HttpStatusCode.InternalServerError
                    , "server_error"
                    , ctx.Exception);
        }
    }
