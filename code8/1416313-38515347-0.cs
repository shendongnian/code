    public class ComputerController : ApiController
    {
        ...
        [HttpGet]
        [Route("api/computer/ping/{id}")]
        public IHttpActionResult Ping(int id)
        {
            return Ok("hello");
        }
        ...
    }
