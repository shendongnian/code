    var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
    {
        Content = new StringContent(string.Join(
            Environment.NewLine,
            ex.GetType().FullName,
            ex.Message))
    };
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
    return response;
