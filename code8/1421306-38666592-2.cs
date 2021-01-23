    public class ValuesController : ApiController
    {
        // GET api/values/1
        [Route("api/values/{id:int}")]
        public IHttpActionResult GetInteger(int id)
        {
            return Ok(id);
        }
    
        // GET api/values/abc
        [Route("api/values/{id:regex([a-zA-Z])}")]
         public IHttpActionResult GetString(string id)
        {
            return Ok(id);
        }
    }
