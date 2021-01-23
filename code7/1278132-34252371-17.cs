    public class TestController : ApiController
    {
        [HttpPost]
        [Route("api/myresource")]
        public HttpResponseMessage Post(MyViewModel viewModel)
        {
            // We will simply echo out the received request object to the response
            var response = Request.CreateResponse(HttpStatusCode.OK, viewModel);
            return response;
        }
    }
