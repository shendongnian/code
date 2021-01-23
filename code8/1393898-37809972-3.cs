	public class SomeController : ApiController
	{
		public IHttpActionResult Post([FromBody] RootObject[] values)
		{
			// do stuff
			return Ok();
		}
	}
