    [RoutePrefix("api/v2/Foo")]
    public class SomeController : ApiController
    {
        [Route("")]
        [HttpGet]
        public Task<int> Get(int param)
        {
            return Task.FromResult(2);
        }
    }
