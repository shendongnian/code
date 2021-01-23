    public class V1Controller : ApiController
    	{
    		public void Put(int id, [FromBody]string value)
    		{
    			HomeController hc = new HomeController();
    			hc.SomeMethod();
    		}
    	}
