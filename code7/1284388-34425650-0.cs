    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(data)));
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
    return result;
