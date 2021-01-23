	[RoutePrefix("Document")]
	public class DocumentController : ApiController
	{
		[HttpPost]
		[Route("AddDocument")]
		public IHttpActionResult AddDocument([FromBody] Document doc)
		{
			//  Do Stuff
			return Ok();
		}
	}
