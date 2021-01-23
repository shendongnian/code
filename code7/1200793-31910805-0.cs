    public HttpResponseMessage Download()
    {
        var path = "test.xml";
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new FileStream(path, FileMode.Open);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
       return result;
    }
