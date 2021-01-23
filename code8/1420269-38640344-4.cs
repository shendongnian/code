    public async Task<HttpResponseMessage> getDataForUploadFiles()
    {
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
    
        var root = HttpContext.Current.Server.MapPath("~/App_Data/Temp/FileUploads");
        Directory.CreateDirectory(root);
        var provider = new MultipartFormDataStreamProvider(root);
        var result = await Request.Content.ReadAsMultipartAsync(provider);
        if (result.FormData["model"] == null)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    
        var model = result.FormData["model"];
        //TODO: Do something with the json model which is currently a string
    
    
    
        //get the files
        foreach (var file in result.FileData)
        {                
            //TODO: Do something with each uploaded file
        }
    
        return Request.CreateResponse(HttpStatusCode.OK, "success!");
    }
