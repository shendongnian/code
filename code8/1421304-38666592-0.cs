    public class ValuesController : ApiController
    {
        // GET api/values/1
        [Route("api/values/{id}")]
        public IHttpActionResult GetInteger(int id)
        {
            return Ok(id);
        }
    
        // GET api/values/1/string
        [Route("api/values/{id}/string")]
        public IHttpActionResult GetString(string id)
        {
            return Ok(id);
        }
    }
