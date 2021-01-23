	public class APIController : ApiController
	{
		private Db dataAccess = new Db();
		
	    [HttpGet]
	    [Route("api/drones")]
	    public HttpResponseMessage getDrones()
	    {
	        var drones = dataAccess.GetDrones();
	        HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drones);
	        return res;
	    }
	
	    [HttpGet]
	    [Route("api/drones/{id}")]
	    public HttpResponseMessage getDrones(int id)
	    {
	        var drone =  dataAccess.GetDrone(int id);
	        HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drone);
	        return res;
	    }
	}
	
