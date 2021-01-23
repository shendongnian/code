    HttpStatusCode statuscode;
    
    if (context.Exception is HttpResponseException)
    {
    	var HTTPex = (HttpResponseException)context.Exception;
    	statuscode = HTTPex.Response.StatusCode;
    }
    else
    {
    	statuscode = HttpStatusCode.InternalServerError;
    } 
    context.response = response;
