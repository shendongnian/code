    [Route("download")]
    [HttpGet]
    public async Task<HttpResponseMessage> GetFile()
    {
        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //don't use a using statement around the stream because the framework will dispose StreamContent automatically
        
        var stream = await SomeMethodToGetFileStreamAsync();
        //buffer size of 4kB
        var content = new StreamContent(stream, 4096);
        response.Content = content;
        return response;
    }
