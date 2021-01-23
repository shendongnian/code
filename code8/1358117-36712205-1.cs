      public class TestController : ApiController
      {
             [ActionName("PostMe")]
             public object PostMe()
             {
             }
    
    		 [ActionName("PostMeTwo")]
             public object PostMeTwo()
             {
             }
    		 
    		[HttpGet]
    		public object TestGet()
    		{
    		
    		}
      }
