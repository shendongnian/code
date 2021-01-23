    [RoutePrefix("api/Foo")]
    public class ValuesController : ApiController
    {
        // get api/Foo/value
        [HttpGet]
        [Route("value")] 
        public IEnumerable<string> NameDoesntMatter()
        {
            return new string[] { "value1", "value2" };
        }
        // get api/Foo/value/123
        [HttpGet]
        [Route("value/{id}")]
        public string AnotherRandomName(int id)
        {
            return "value";
        }
