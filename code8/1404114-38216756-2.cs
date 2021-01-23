    //the response type
	public class SimpleRes
    {
        [JsonProperty(PropertyName = "result")]
        public string Result;      
    }
	//the controller
	 public class TestController : ApiController
	 { 	
	 	[HttpGet] 
	    [HttpPost]
	    [JSONAPIFilter]
	    public SimpleRes TestAction()
	    {
	        return new SimpleRes(){Result = "hello world!"};
	    }
	 }
