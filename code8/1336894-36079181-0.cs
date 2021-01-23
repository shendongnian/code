    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
            FileName = fileName.ToString()
    };
    response.Content.Headers.ContentLength=stream.Length.ToString();
    
