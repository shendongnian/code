    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/home")]
    public class HomeV1Controller : Controller
    {
    	[HttpGet]
    	public string Get() => "Version 1";
    }
     
    [ApiVersion("2.0")]
    [Route("api/{version:apiVersion}/home")]
    public class HomeV2Controller : Controller
    {
    	[HttpGet]
    	public string Get() => "Version 2";
    }
