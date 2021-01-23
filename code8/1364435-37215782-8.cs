	using System;
	using System.Collections.Specialized;
	using System.Web;
	public class StubHttpContextForRouting : HttpContextBase
	{
		StubHttpRequestForRouting _request;
		StubHttpResponseForRouting _response;
		public StubHttpContextForRouting(string appPath = "/", string requestUrl = "~/")
		{
			_request = new StubHttpRequestForRouting(appPath, requestUrl);
			_response = new StubHttpResponseForRouting();
		}
		public override HttpRequestBase Request
		{
			get { return _request; }
		}
		public override HttpResponseBase Response
		{
			get { return _response; }
		}
		public override object GetService(Type serviceType)
		{
			return null;
		}
	}
	public class StubHttpRequestForRouting : HttpRequestBase
	{
		string _appPath;
		string _requestUrl;
		public StubHttpRequestForRouting(string appPath, string requestUrl)
		{
			_appPath = appPath;
			_requestUrl = requestUrl;
		}
		public override string ApplicationPath
		{
			get { return _appPath; }
		}
		public override string AppRelativeCurrentExecutionFilePath
		{
			get { return _requestUrl; }
		}
		public override string PathInfo
		{
			get { return ""; }
		}
		public override NameValueCollection ServerVariables
		{
			get { return new NameValueCollection(); }
		}
	}
	public class StubHttpResponseForRouting : HttpResponseBase
	{
		public override string ApplyAppPathModifier(string virtualPath)
		{
			return virtualPath;
		}
	}
