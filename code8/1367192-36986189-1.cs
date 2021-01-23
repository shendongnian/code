    [HttpPost]
    public HttpResponseMessage Download(string fileName)
    {   
        string filePath = Path.Combine(PATH, fileName.Replace('/', '\\'));
        byte[] pdf = System.IO.File.ReadAllBytes(filePath);
        //content length for header
        var contentLength = pdf.Length;
        var statuscode = HttpStatusCode.OK;
        var result = Request.CreateResponse(statuscode);
        result.Content = new StreamContent(new MemoryStream(buffer));
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        result.Content.Headers.ContentLength = contentLength;
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        result.Content.Headers.ContentDisposition.FileName = "MyPdf.pdf";
        
        return result;
    }
