         public HttpResponseMessage Post()
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach(string file in httpRequest.Files)
                    {                   
     var content = new MultipartFormDataContent
            {
                JsonApiClient.CreateFileContent(postedFile.InputStream, postedFile.FileName, postedFile.ContentType)
            };
                     // NOTE: To store in memory use postedFile.InputStream
                    }
            
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
    
    
        internal static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
            {
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"files\"",
                    FileName = "\"" + fileName + "\""
                }; 
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                return fileContent;
            }
