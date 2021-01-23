	public class MyAuthorizeAttribute : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized");
		}
	}
