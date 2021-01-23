    public async Task<HttpResponseMessage> Post()
    {
        //make sure the post we have contains multi-part data
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        //read data
        var provider = new MultipartMemoryStreamProvider();
        await Request.Content.ReadAsMultipartAsync(provider);
        //declare backup file summary and file data vars
        var content = new Content();
        var config = new Config();
        //iterate over contents to get Content and Config
        foreach (var requestContents in provider.Contents)
        {
            if (requestContents.Headers.ContentDisposition.Name == "Content")
            {
                content = JsonConvert.DeserializeObject<Content>(requestContents.ReadAsStringAsync().Result);
            }
            else if (requestContents.Headers.ContentDisposition.Name == "Config")
            {
                config = JsonConvert.DeserializeObject<Config>(requestContents.ReadAsStringAsync().Result);
            }
        }
        //do something here with the content and config and set success flag
        var success = true;
        
        //indicate to caller if this was successful
        HttpResponseMessage result = Request.CreateResponse(success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, success);
        return result;
    }
}
