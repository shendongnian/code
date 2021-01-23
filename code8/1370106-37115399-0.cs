    public class ValuesController : ApiController
    {
        [SwaggerOperation(Tags = new[] { "Test" })]
        public IHttpActionResult Get()
        {
            // ...
        }
    }
