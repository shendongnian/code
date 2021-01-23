    [TestMethod]
    [ExpectedException(typeof(HttpRequestException))]
    public async Task Test()
    {
        var content = new ContentWithException();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("http://localhost/mypdfDownload").Respond(content);
        
        var client = new HttpClient(mockHttp);
        var response = await client.GetAsync("http://localhost/mypdfDownload");
        await response.Content.ReadAsByteArrayAsync();
    }
    private class ContentWithException : HttpContent
    {
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            throw new HttpRequestException();
        }
        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }
    }
