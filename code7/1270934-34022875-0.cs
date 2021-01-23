	public class CookieAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
	{
		public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			// your cookie code
		}
	}
