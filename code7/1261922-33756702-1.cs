    [HttpPost]
    public async Task<HttpResponseMessage> UploadFileToDocmentLibrary()
    {
        if (!this.Request.Content.IsMimeMultipartContent())
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        try
        {
            var loProvider = new MultipartFormDataStreamProvider(Path.GetTempPath());
    
            await Request.Content.ReadAsMultipartAsync(loProvider);
    
            string lsFilename = loProvider.FormData.GetValues("filename").First();
            var loFile = loProvider.FileData.First();
            string lsFileContent = File.ReadAllText(loFile.LocalFileName);             
    
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        catch (Exception exp)
        {
            return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exp);
        }
    }
