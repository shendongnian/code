    [RouteVersion("api/versiontest", 1)]
	public class Version1TestController : BaseApiController
	{
        // get: api/versiontest
		[HttpGet]
        public HttpResponseMessage get()
        {
			return Request.CreateResponse(HttpStatusCode.OK, new { Version = "API Version 1 selected" });
        }
    }
    [RouteVersion("api/versiontest", 2)]
	public class Version2TestController : ApiController
	{
        // get: api/versiontest
		[HttpGet]
		public HttpResponseMessage get()
		{
			return Request.CreateResponse(HttpStatusCode.OK, new { Version = "API Version 2 selected" });
		}
    }
