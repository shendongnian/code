    public class InternalRequest : IRequest
	{
		public string GetRawBody() { throw new NotImplementedException(); }
		public T TryResolve<T>() { return HostContext.TryResolve<T>(); }
		public object OriginalRequest { get; set; }
		public IResponse Response { get; set; }
		public string OperationName { get; set; }
		public string Verb { get; set; }
		public RequestAttributes RequestAttributes { get; set; }
		public IRequestPreferences RequestPreferences { get; set; }
		public object Dto { get; set; }
		public string ContentType { get; set; }
		public bool IsLocal { get; set; }
		public string UserAgent { get; set; }
		public IDictionary<string, Cookie> Cookies { get; set; }
		public string ResponseContentType { get; set; }
		public bool HasExplicitResponseContentType { get; set; }
		public Dictionary<string, object> Items { get; set; }
		public INameValueCollection Headers { get; set; }
		public INameValueCollection QueryString { get; set; }
		public INameValueCollection FormData { get; set; }
		public bool UseBufferedStream { get; set; }
		public string RawUrl { get; set; }
		public string AbsoluteUri { get; set; }
		public string UserHostAddress { get; set; }
		public string RemoteIp { get; set; }
		public bool IsSecureConnection { get; set; }
		public string[] AcceptTypes { get; set; }
		public string PathInfo { get; set; }
		public System.IO.Stream InputStream { get; set; }
		public long ContentLength { get; set; }
		public IHttpFile[] Files { get; set; }
		public Uri UrlReferrer { get; set; }
	}
