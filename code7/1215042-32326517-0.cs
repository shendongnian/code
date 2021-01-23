	[RoutePrefix("api/invitations")]
	public class InvitationsApiController : ApiController
	
	[Route("")]
	[HttpPost]
	public IHttpActionResult Create([FromBody] CreateCommand command)
