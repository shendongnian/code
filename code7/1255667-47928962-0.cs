    [Route("{id}")]
    public HttpResponseMessage GetImage(int id)
    {
        HttpResponseMessage resp = new HttpResponseMessage();
        if (File.Exists(@"c:\files\myfile.file"))
        {
            resp.StatusCode = HttpStatusCode.NotFound;
            return resp;
        }
        // file exists - try to stream it
        resp.Content = new PushStreamContent(async (responseStream, content, context) =>
        {
            // can't do anything here, already sent a 200.
            await CopyBinaryValueToResponseStream(responseStream, id);
        });
        return resp;
    }
