    public async Task<IHttpActionResult> UploadBridgeImage()
    {
        var provider = await Request.Content.ReadAsMultipartAsync(new MultipartFormDataInMemoryStreamProvider());
        foreach (var fileContent in provider.Contents)
        {
            var byteArray = await fileContent.ReadAsByteArrayAsync();
            //do whatever you need with byteArray
        }
        var bridgeId = provider.FormData["bridgeId"];
        return Ok();
    }
