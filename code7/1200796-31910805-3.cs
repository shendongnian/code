       using System.Net;
       using System.Net.Http;
       using System.Net.Http.Headers;
       using System.Text;
       using System.Web.Http;
    
       namespace WebApplication1.Controllers
       {
        public class ValuesController : ApiController
        {
            // GET: api/Values
            public HttpResponseMessage Get()
            {
                var xmlString = "<xml><name>Some XML</name></xml>";
                var result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StringContent(xmlString, Encoding.UTF8, "application/xml");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "test.xml"
                };
    
                return result;
            }
        }
       }
