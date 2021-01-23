    public class ValuesController : ApiController
    {
        // POST api/values
    	[HttpPost] // added attribute
        public IHttpActionResult Post([FromBody] string filterName) // added FromBody as this is how you are sending the data
        {
            return new JsonResult<string>(filterName, new JsonSerializerSettings(), Encoding.UTF8, this);
        }
