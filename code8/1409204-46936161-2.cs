     [ApiVersion( "1.0" )]
     [Route( "api/v{version:apiVersion}/[controller]" )]
     public class HelloWorldController : Controller {
        public string Get() => "Hello world!";
     }
    [ApiVersion( "2.0" )]
    [ApiVersion( "3.0" )]
    [Route( "api/v{version:apiVersion}/helloworld" )]
    public class HelloWorld2Controller : Controller {
        [HttpGet]
        public string Get() => "Hello world v2!";
     
        [HttpGet, MapToApiVersion( "3.0" )]
        public string GetV3() => "Hello world v3!";
    }
