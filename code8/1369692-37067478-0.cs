    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    namespace Sample.API.Controllers
    {
        public class ContentDataController
        {
    
            [Route("api/ContentData")]
            [HttpPost]
           
            public HttpResponseMessage SamplePost(SampleRequest request)
            {
                HttpResponseMessage response;
                try
                {
                    var cda = dataContentAdapter(); 
                    //Business logic here
                    var result = cda.GetContent(request);
                    //pass the above result to angular
                    response = Request.CreateResponse(HttpStatusCode.OK, result);
                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                }
                catch (Exception ex)
                {
                    ApplicationLogger.LogCompleteException(ex, "ContentDataController", "Post");
                    HttpError myCustomError = new HttpError(ex.Message) { { "IsSuccess", false } };
                    return Request.CreateErrorResponse(HttpStatusCode.OK, myCustomError);
                }
                return response;
            }
        }
    }
