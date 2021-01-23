    byte[] result = converter.Convert(document);
    MemoryStream ms = new MemoryStream(result);
    
    response.StatusCode = HttpStatusCode.OK;
    response.Content = new StreamContent(ms);
    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
    response.Content.Headers.Add("content-disposition", "attachment;filename=myFile.pdf");
    return response;
