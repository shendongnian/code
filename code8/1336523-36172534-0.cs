    public interface IPostHandler
	{
		Task<HttpResponseMessage> BeginPost(HttpContent content, string requestUri);
	}
    public class AndroidPostHandler : IPostHandler
	{
		public async Task<HttpResponseMessage> BeginPost(HttpContent content, string requestUri)
		{
			using (var client = new HttpClient(new NativeMessageHandler()))
			{
				var response = await client.PostAsync(baseUrl, content);
				return response;
			}
		}
    }
