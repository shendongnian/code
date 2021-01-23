    [HttpPost]
    public async Task<HttpResponseMessage> Upload(string authCode, int id)
    {
        var request = Request;
    
        var provider = new CustomMultipartFormDataStreamProvider(root);
    
        await request.Content.ReadAsMultipartAsync(provider);
        return new HttpResponseMessage()
        {
            Content = new StringContent("File uploaded successfully"),
            StatusCode = HttpStatusCode.OK
        };
    }
