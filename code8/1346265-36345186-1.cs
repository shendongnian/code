    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new ByteArrayContent(excelContents);
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
    result.Content.Headers.ContentDisposition.FileName = "blah.xlsx";
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    
    return result;
