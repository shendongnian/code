    [Route("api/applications/custom")]
    [HttpPost]
    public async Task<HttpResponseMessage> Upload()
    {
        MultipartMemoryStreamProvider memoryStreamProvider;
        try
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            memoryStreamProvider = await Request.Content.ReadAsMultipartAsync();
        }
        catch (Exception e)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, string.Format("An error has occured while uploading your file. Error details: '{0}'", e.Message));    
        }
        // do something with your file...
        return Request.CreateResponse(HttpStatusCode.OK);
    }
