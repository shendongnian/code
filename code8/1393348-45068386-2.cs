	[Route("[controller]")]
	public class ErrorController : Controller
	{
		[Route("")]
		[AllowAnonymous]
		public IActionResult Get()
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
