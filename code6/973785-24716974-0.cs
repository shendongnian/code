    public IHttpActionResult ThrowHttpException(HttpStatusCode code, string content)
    {
        string message = JsonConvert.SerializeObject(new { message = content });
        var resp = new HttpResponseMessage(code)
        {
            Content = new StringContent(message),
            ReasonPhrase = null
        };
        return resp;
    }
