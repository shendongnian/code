    public class Filter {
        public string FilterName {get;set;}
    }
    public class ValuesController : ApiController
    {
        // POST api/values
    	[HttpPost] // added attribute
        public IHttpActionResult Post([FromBody] Filter filter) // added FromBody as this is how you are sending the data
        {
            return new JsonResult<string>(filter.FilterName, new JsonSerializerSettings(), Encoding.UTF8, this);
        }
