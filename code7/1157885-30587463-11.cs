    [AllowAnonymous]
    public class TestController : ApiController
    {
        [DeleteRoute("api/test")]
        public IHttpActionResult Endpoint1()
        {
            return this.Ok("endpoint1");
        }
    }
    [AllowAnonymous]
    public class TestController2 : ApiController
    {
        [PostRoute("api/test")]
        public IHttpActionResult Endpoint2()
        {
            return this.Ok("endpoint2");
        }
    }
