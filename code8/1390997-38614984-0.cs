    [Route(""), HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)]
    public HttpResponseMessage RedirectToSwaggerUi()
    {
        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Found);
        httpResponseMessage.Headers.Location = new Uri("/swagger/ui/index", UriKind.Relative);
        return httpResponseMessage;
    }
