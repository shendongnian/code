    [HttpPost]
    public async Task<JsonResult> AnalyseFile()
    {
         if (!Request.Content.IsMimeMultipartContent())
         {
           //If not throw an error
           throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
         }
        MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider("c:\\tmp\\uploads");
       
        // Read the MIME multipart content using the stream provider we just created.
        IEnumerable<HttpContent> bodyparts = await Request.Content.ReadAsMultipartAsync(streamProvider);
        // Get a dictionary of local file names from stream provider.
        // The filename parameters provided in Content-Disposition header fields are the keys.
        // The local file names where the files are stored are the values.
        IDictionary<string, string> bodyPartFileNames = streamProvider.BodyPartFileNames;
       
        //rest of code here
       
    }
