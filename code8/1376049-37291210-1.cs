    [HttpPost]
        [Route("{controller}/upload/{fileName}/{filePath}")]
        public async Task<HttpResponseMessage> UploadFile(string fileName, string filePath)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "The request doesn't contain valid content!");
            }
            byte[] data = Convert.FromBase64String(filePath);
            filePath = Encoding.UTF8.GetString(data);
            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var dataStream = await file.ReadAsStreamAsync();
                    // use the data stream to persist the data to the server (file system etc)
                    using (var fileStream = File.Create(filePath + fileName))
                    {
                        dataStream.Seek(0, SeekOrigin.Begin);
                        dataStream.CopyTo(fileStream);
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Successful upload", Encoding.UTF8, "text/plain");
                    response.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue(@"text/html");
                    return response;
                }
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
