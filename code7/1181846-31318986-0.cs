    [RoutePrefix("api/Foo")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("value")]
        public IEnumerable<string> SomeRandomName()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        [Route("value/{id}")]
        public string AnotherRandomName(int id)
        {
            return "value";
        }
