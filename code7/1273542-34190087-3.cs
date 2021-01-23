     public async Task<HttpResponseMessage> Post()
    {
    HttpResponseMessage response;
        //Check if request is MultiPart
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        //This specifies local path on server where file will be created
        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);
        //This write the file in your App_Data with a random name
        await Request.Content.ReadAsMultipartAsync(provider);
        foreach (MultipartFileData file in provider.FileData)
        {
            //Here you can get the full file path on the server
            //and other data regarding the file
            //Point to note, this is only filename. If you want to keep / process file, you need to stream read the file again.
            tempFileName = file.LocalFileName;
        }
        // You values are inside FormData. You can access them in this way
        foreach (var key in provider.FormData.AllKeys)
        {
            foreach (var val in provider.FormData.GetValues(key))
            {
                Trace.WriteLine(string.Format("{0}: {1}", key, val));
            }
        }
        //Or directly (not safe)    
        string name = provider.FormData.GetValues("name").FirstOrDefault();
        response = Request.CreateResponse(HttpStatusCode.Ok);              
    return response;
    }
