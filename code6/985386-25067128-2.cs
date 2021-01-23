    public class IndexController : ApiController
    {
        [AllowAnonymous]
        [Route("")]
        public HttpResponseMessage GetIndex()
        {
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            response.Headers.Location = new Uri(fullyQualifiedUrl + "/help");
            return response;
        }
    }
