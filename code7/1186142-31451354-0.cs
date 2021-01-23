    public override void OnException(HttpActionExecutedContext context)
    {
        throw new HttpResponseException(
            new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("The content"),
                ReasonPhrase = "The reason"
            });
    }
