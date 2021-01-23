	public class AllowLocalExcludingLBAttribute : RequestFilterAttribute
	{
		public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
		{
			// If the request is not local or it belongs to the load balancer then throw an exception
			if(!req.IsLocal || req.RemoteIp == "10.0.0.1")
				throw new HttpError(System.Net.HttpStatusCode.Forbidden, "403", "Service can only be accessed internally");
		}
	}
