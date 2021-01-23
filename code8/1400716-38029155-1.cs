    namespace System.Web.Mvc
    {
    	//
    	// Summary:
    	//     Specifies that access to a controller or action method is restricted to users
    	//     who meet the authorization requirement.
    	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    	public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    .........
