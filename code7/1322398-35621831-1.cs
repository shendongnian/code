    public HttpResponseMessage GetStyle(string name)
    {
        var response = new HttpResponseMessage()
        {
            Content = GetFileContent(name)
        };
    
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/css");
        return response;
    }
    
    private StringContent GetFileContent(string name)
    {
        //TODO: fetch the file, read its contents
        return new StringContent(content);
    }
