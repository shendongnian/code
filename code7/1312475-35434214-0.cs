	public class WebDependency : IWebDependency
	{
		public HttpWebRequest GetWebRequest(string uri)
		{
			var request = WebRequest.Create (uri) as HttpWebRequest;
			request.SendChunked = true;
			request.AllowWriteStreamBuffering = false;
			return request;
		}
	}
