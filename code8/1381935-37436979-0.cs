	[RoutePrefix("MyController")]
	public class MyController : ApiController
	{
	   [HttpDelete]
	   [Route("delete/{id:int}")]
	   public IHttpActionResult Delete(int id) {..}
		
	   [HttpDelete]
	   [Route("delete/{id:guid}")]
	   public IHttpActionResult Delete2(Guid id) {..}
	   [HttpDelete]
	   [Route("delete/{id:alpha}")]
	   public IHttpActionResult       Delete3(string id) {..}
	}
