    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            WebClient webClient = new WebClient();
            byte[] pdfContent = webClient.DownloadData("http://www.bodossaki.gr/userfiles/file/dummy.pdf");
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            string fileName = Path.GetFileName("http://www.bodossaki.gr/userfiles/file/dummy.pdf");
            result.Content = new ByteArrayContent(pdfContent);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = fileName;
            return result;
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
