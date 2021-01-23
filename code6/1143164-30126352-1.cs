    [Route("")]
    public HttpResponseMessage GetFile()
    {
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        try
        {
            var file = XLGeneration.XLGeneration.getXLFileExigence();
            result.Content = new StreamContent(file);
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            var value = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            value.FileName = "Whatever your filename is";
            result.Content.Headers.ContentDisposition = value;
        }
        catch (Exception ex)
        {
            // log your exception details here
            result = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
        return result;
    }
