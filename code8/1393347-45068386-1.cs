	[Route("[controller]")]
	public class ErrorController : Controller
	{
		[Route("")]
		[AllowAnonymous]
		public IActionResult Get()
		{
			return StatusCode(500);
		}
	}
