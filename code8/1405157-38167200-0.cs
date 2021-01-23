    public override void OnException(HttpActionExecutedContext context)
    {
        var exception = context.Exception as DbEntityValidationException;
        if (exception == null)
            return;
        var errors = exception.EntityValidationErrors.SelectMany(_ => _.ValidationErrors);
        var messages = errors.Select(_ => Culture.Current($"{_.PropertyName}:{_.ErrorMessage}"));
        var message = Culture.Current($"{context.Exception.Message}<br/>{string.Join("<br/>", messages)}");
        // create an error response containing all the required detail...
        var response = context.Request.CreateErrorResponse(
             HttpStatusCode.InternalServerError,
             message,
             exception);
        throw new HttpResponseException(response);
    }
