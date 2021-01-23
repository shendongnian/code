    [HttpGet][Route("export/pdf")]
    public HttpResponseMessage ExportAsPdf()
    {
        MemoryStream memStream = new MemoryStream();
        PdfExporter.Instance.Generate(memStream);
    
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(memStream.GetBuffer())
        };
        result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        {
            FileName = "YourName.pdf"
        };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        return result;
    }
