    ZipFile zip = new ZipFile()
    // Do something with 'zip'
    var pushStreamContent = new PushStreamContent((stream, content, context) =>
    {
        zip.Save(stream);
        stream.Close();
    }, "application/zip");
    HttpResponseMessage response = new HttpResponseMessage
    {
        Content = pushStreamContent,
        StatusCode = HttpStatusCode.OK
    };
    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = "fileName"
    };
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
    return response;
