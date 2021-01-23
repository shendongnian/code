	public class HttpException : Exception
	{
		public HttpException(HttpStatusCode statusCode) { StatusCode = statusCode; }
		public HttpStatusCode StatusCode { get; private set; }
	}
