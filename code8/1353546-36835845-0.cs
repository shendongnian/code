    public class YourController : YourMediaResourceODataController<YourZIPObjectEntity, string>
    {
        // This would be the post
        public async Task<IHttpActionResult> Post()
        {
            var stream = await Request.Content.ReadAsStreamAsync();
            // Manage the stream
        }
        // The get (if you want it, you will need to code the custom EntityRoutingConvention).
        [HttpGet]
        public HttpResponseMessage GetMediaResource(string key)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var theZIPFile = yourZIPFileService.GetZIPFileByKey(key);
            StreamContent contentResult;
            using(var ms = new MemoryStream(theZIPFile.theByteArray)
            {
                contentResult = new StreamContent(ms);
            }
            
            result.Content = contentResult;
            return result;
        }
    }
