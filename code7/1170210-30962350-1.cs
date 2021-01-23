    public class WebServiceController : ApiController
    {
        [HttpGet]
        [Route("api/WebService")]
        public IHttpActionResult Post(MyRequest request)
        { 
            //work
            return StatusCode(HttpStatusCode.OK);
        }
    }
    public class MyRequest
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
