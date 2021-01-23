    [HttpGet]
    public async Task<IHttpActionResult> GetVideo(int videoId)
    {
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        result.Content = new PushStreamContent(async (outputStream, _, __) =>
        {
            try             
            {
                // Stream from Azure (you can change this to stream from a file etc.)
                CloudBlockBlob blockBlob = Container.GetBlockBlobReference(String.Format("video-{0}.mp4", videoId));
                await blockBlob.DownloadToStreamAsync(id, outputStream);
            }
            finally
            {
                outputStream.Close();
            }
        });
        // Assuming videos stored as MP4
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
        return result;
    }
