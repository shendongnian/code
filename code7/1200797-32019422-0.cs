    public HttpResponseMessage Get(string fileName)
    {
        FileStream fileStream = FileProvider.Open(fileName);
        var response = new HttpResponseMessage();
        response.Content = new StreamContent(fileStream);
        response.Content.Headers.ContentDisposition 
                          = new ContentDispositionHeaderValue("attachment");
        response.Content.Headers.ContentDisposition.FileName = fileName;
        response.Content.Headers.ContentType
                         = new MediaTypeHeaderValue("application/octet-stream");
        response.Content.Headers.ContentLength 
                         = FileProvider.GetLength(fileName);
        return response;
