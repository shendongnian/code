    var uploadPath = HttpContext.Current.Server.MapPath("~/Content/upload/products/");
    
    var stream = new FileStream(uploadPath + "\\" + fileName, FileMode.Open, FileAccess.Read);
    var memoryStream = new MemoryStream();
    stream.CopyTo(memoryStream);
    //content length for header
    var contentLength = memoryStream.Length;
    var response = new HttpResponseMessage();
    response.Headers.AcceptRanges.Add("bytes");
    response.StatusCode = HttpStatusCode.OK;
    response.Content = new StreamContent(memoryStream);
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    response.Content.Headers.ContentLength = contentLength;
    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = Path.GetFileName(uploadPath + "\\" + fileName)
    };
    
    
    return response;
