    public HttpResponseMessage GetDocument(int id)
    {
        var filename = $"folder/{id}.pdf";
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(System.IO.File.ReadAllBytes(filename))
        };
        result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
        {
            FileName = $"{id}.pdf"
        };
        result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
        // I need to delete file after me
        System.IO.File.Delete(filename);
        return result;
    }
  
