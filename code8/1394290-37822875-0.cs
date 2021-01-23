    [HttpGet][Route("export/pdf")]
    public HttpResponseMessage ExportAsPdf()
    {
        MemoryStream memStream = new MemoryStream();
        PdfExporter.Instance.Generate(memStream);
    
        //get buffer
        var buffer = memStream.GetBuffer();
        //content length for header
        var contentLength = buffer.Length;
    
        var statuscode = HttpStatusCode.OK;
        var response = Request.CreateResponse(statuscode);
        response.Content = new StreamContent(new MemoryStream(buffer));
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        response.Content.Headers.ContentLength = contentLength;
        ContentDispositionHeaderValue contentDisposition = null;
        if (ContentDispositionHeaderValue.TryParse("inline; filename=my_filename.pdf", out contentDisposition)) {
            response.Content.Headers.ContentDisposition = contentDisposition;
        }
    
        return response;
    }
