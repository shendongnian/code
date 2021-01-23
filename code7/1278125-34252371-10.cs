    public class TestController : ApiController
    {
        [HttpPost]
        [Route("api/myresource")]
        public HttpResponseMessage Post(MyViewModel viewModel)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, viewModel);
            return response;
        }
    }
