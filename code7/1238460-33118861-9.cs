	public class CustomMiddleware
	{
		private IPersonService _personService;
		public CustomMiddleware(IPersonService personService) {
			_personService = personService;
		}
		public async Task Invoke(HttpContext context, RequestDelegate next) { /* ... */ }
	}
