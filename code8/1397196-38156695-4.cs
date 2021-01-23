    public async Task<IHttpActionResult> UploadBridgeImage()
    {
        var provider = await Request.Content.ReadAsMultipartAsync(new MultipartFormDataInMemoryStreamProvider());
        foreach (var httpContent in provider.Contents)
        {
            if (!string.IsNullOrEmpty(httpContent.Headers.ContentDisposition?.FileName))
            {
                var byteArray = await httpContent.ReadAsByteArrayAsync();
                //do whatever you need with byteArray
            }
        }
        var bridgeId = provider.FormData["bridgeId"];
        return Ok();
    }
