	[Route("[controller]")]
	public class ErrorController : Controller
	{
		[HttpGet, Route("")]
		[AllowAnonymous]
		public IActionResult Get()
		{
			return StatusCode(500);
		}
	}
