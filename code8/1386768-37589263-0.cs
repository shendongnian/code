    [RoutePrefix("v1/myexample")]
    public MyController : ApiController {
        [Route("foo")]
        public string GetFoo()
        {
            return "foo";
        }
    }
