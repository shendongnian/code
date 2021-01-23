    // in your startup configuration:
    config.MapHttpAttributeRoutes();
    // and your controller:
    [RoutePrefix("foo")]
    public class FooController
    {
        [HttpGet]
        [Route("bar/{param1}/{param2}")]
        [Route("bar")
        public IHttpActionResult GetBar(string param1, string param2)
        {
            // ...
        }
    }
