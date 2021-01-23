	using System.Security.Claims;
	using System.Web.Mvc;
	namespace ProudSourcePrime.Config
	{
		public class AppUserPrincipal : ClaimsPrincipal
		{
			public AppUserPrincipal(ClaimsPrincipal principal) : base(principal)
			{
			}
			public string Name
			{
				get
				{
					return this.FindFirst(ClaimTypes.Name).Value;
				}
			}
		}
		public abstract class AppController : Controller
		{
			public AppUserPrincipal CurrentUser
			{
				get
				{
					return new AppUserPrincipal(this.User as ClaimsPrincipal);
				}
			}
		}
		/// <summary>
		/// Custom base view page to be inherited by all Razor Views in the web application.
		/// 
		/// This provides access too our AppUser principal.
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		public abstract class AppViewPage<TModel> : WebViewPage<TModel>
		{
			protected AppUserPrincipal CurrentUser
			{
				get
				{
					return new AppUserPrincipal(this.User as ClaimsPrincipal);
				}
			}
		}
		public abstract class AppViewPage : AppViewPage<dynamic>
		{
		}
	}
