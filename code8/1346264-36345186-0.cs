    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new ByteArrayContent(excelContents);
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    
    return result;
