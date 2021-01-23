	public class JsonProtector : DelegatingHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(
					HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
			// Manipulate response here.
			return response;
		}
	}
	
