    public override void OnException(HttpActionExecutedContext ctx)
            {
                log.Error(ctx.Exception.Message, ctx.Exception);
    
                if(ctx.Exception is HttpResponseException 
                    && 
                    ((HttpResponseException)ctx.Exception).Response.IsNotNull())
                {
                    var response = ((HttpResponseException)ctx.Exception).Response;
                    ctx.Response = ApiResponseFactory.CreateErrorResponse(response.StatusCode
                           , response.ReasonPhrase, ctx.Exception.Message);
                }
                else
                {
                    ctx.Response = ApiResponseFactory.CreateErrorResponse(HttpStatusCode.InternalServerError
                        , "server_error"
                        , ctx.Exception);
                }
            }
