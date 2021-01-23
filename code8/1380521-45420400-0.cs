        [Route("ImportRecords")]                
        [HttpPost] 
        public async Task<HttpResponseMessage> ImportRecords()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            
            string tempFilesPath = "some temp path for the stream"
            var streamProvider = new MultipartFormDataStreamProvider(tempFilesPath);
            var content = new StreamContent(HttpContext.Current.Request.GetBufferlessInputStream(true));
            foreach (var header in Request.Content.Headers)
            {
                content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            var data = await content.ReadAsMultipartAsync(streamProvider);
            
            //this is where you get your parameters
            string clientId = data.FormData["clientId"];                     
            ...
        }
