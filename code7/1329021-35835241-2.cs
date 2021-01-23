    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    namespace Some.Namespace
    {
        public class SomeController : ApiController
        {
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
                IEnumerable<HttpContent> bodyparts = await  Request.Content.ReadAsMultipartAsync(streamProvider);
                // Get a dictionary of local file names from stream provider.
                // The filename parameters provided in Content-Disposition header fields are the keys.
                // The local file names where the files are stored are the values.
                //depending on your version of .net, this might have been changed to FileData instead. 
                // see: https://msdn.microsoft.com/en-us/library/system.net.http.multipartformdatastreamprovider(v=vs.118).aspx
                IDictionary<string, string> bodyPartFileNames = streamProvider.BodyPartFileNames;
       
                //rest of code here
       
        }
    }
