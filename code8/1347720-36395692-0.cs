    public async Task<HttpResponseMessage> PostFormData(HttpRequestMessage request)
        {
            // Check if the request contains multipart/form-data.
           if (!request.Content.IsMimeMultipartContent("form-data"))
                {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
    
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
    
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
    
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
