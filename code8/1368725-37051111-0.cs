    HttpResponseMessage response = Request.CreateResponse();
    using (WebClient webClient = new WebClient())
    {
        string url = string.Format(PHOTO_GET, filePath);
        var memoryStream = new MemoryStream(webClient.DownloadData(url));
        
        response.Headers.AcceptRanges.Add("bytes");
        response.StatusCode = HttpStatusCode.OK;
        response.Content = new StreamContent(memoryStream);
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("render");
        response.Content.Headers.ContentDisposition.FileName = fileName;
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        response.Content.Headers.ContentLength = memoryStream.Length;            
    }
    return response;
