    [ApiVersion( "2.0" )]
    [Route( "api/helloworld" )]
    public class HelloWorld2Controller : Controller {
        [HttpGet]
        public string Get() => "Hello world!";
    }
