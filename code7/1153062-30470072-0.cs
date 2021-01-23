    // To create multipartcontent 
    // 404 is an error in my url address
        
                private static HttpContent CreateMultipartContent(JToken json, string markupText, string fileName)
                {
                    MultipartContent content = new MultipartContent("form-data", Guid.NewGuid().ToString());
        
                    StringContent jsonPart = new StringContent(json.ToString());
                    jsonPart.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    jsonPart.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
                    StringContent filePart = new StringContent(markupText);
                    filePart.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                    filePart.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    filePar`enter code here`t.Headers.ContentDisposition.FileName = fileName;
        
                    content.Add(jsonPart);
                    content.Add(filePart);
        
                    return content;
                }
