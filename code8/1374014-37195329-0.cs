    public class MyTestController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] object gem)
        {
            return new StatusCodeResult((HttpStatusCode)422, this);
        }
    }
