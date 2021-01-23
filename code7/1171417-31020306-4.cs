    [HttpPut]
    [Route(@"api/storage/{*resourcePath?}")]
    public async Task<HttpResponseMessage> PutFile(string resourcePath = "")
    {
        // Extract data from request
        Stream fileContent = await this.Request.Content.ReadAsStreamAsync();
        MediaTypeHeaderValue contentTypeHeader = this.Request.Content.Headers.ContentType;
        string contentType =
            contentTypeHeader != null ? contentTypeHeader.MediaType : "application/octet-stream";
        // Save the file to the underlying storage
        bool isNew = await this._dal.SaveFile(resourcePath, contentType, fileContent);
        // Return appropriate HTTP status code
        if (isNew)
        {
            return this.Request.CreateResponse(HttpStatusCode.Created);
        }
        else
        {
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
