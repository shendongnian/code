    [HttpPost]
    public async Task<HttpResponseMessage> Post(string id)
    {
        var bytes = await Request.Content.ReadAsByteArrayAsync();
        IoSys.Root = new IoSys {InputStream = new MemoryStream(bytes)};
        var model = new DrawingChain().Load();
        IoSys.Root.CloseIn();
        var stream = new MemoryStream() // Is it right here?
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = = new StreamContent(stream);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        IoSys.Root = new IoSys {OutputStream = stream};
        model.Save();
        return result;
    }
