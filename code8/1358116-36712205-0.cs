      public class TestController : ApiController
      {
             [ActionName("GetMe")]
             public object GetMe()
             {
             }
    
    		 [ActionName("GetMeTwo")]
             public object GetMeTwo()
             {
             }
    		 
    		[HttpGet]
    		public object TestGet()
    		{
    		
    		}
      }
