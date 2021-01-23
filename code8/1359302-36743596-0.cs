    [RoutePrefix("api/myController")]
    public class MyController : ApiController
    {
    
        [Route("myAction/{version}")]
        public HttpResponseMessage MyAction(int version)
        {
    	     switch (version){
                   case 1:
                     ...
                   break;
    	           case 2:
                     ...
                   break;
              }
              ......
    	}   
    
    }
