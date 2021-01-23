    [HttpPost]
    public async Task<IHttpActionResult> Post()
    {
        if (!Request.Content.IsMimeMultipartContent())
        {
            return this.StatusCode(HttpStatusCode.UnsupportedMediaType);
        }
        var filesProvider = await Request.Content.ReadAsMultipartAsync();
        var fileContents = filesProvider.Contents.FirstOrDefault();
        if (fileContents == null)
        {
            return this.BadRequest("Missing file");
        }
        var headers = fileContents.Headers;
        string filename = headers.ContentDisposition.FileName;
        Stream fileStream = await fileContents.ReadAsStreamAsync();
        ... do something with the file name and stream
    }
