			config.Routes.MapHttpRoute(
				name: "CatchAllRoute",
				routeTemplate: "{*catchall}",
				defaults: new { controller = "UnrecognizedRoute", action = ApiConstants.UnrecognizedRouteAction });
...
	public class UnrecognizedRouteController : ApiController
	{
		/// <summary>
		/// This method is called for every single API request that comes to the API and is not routed
		/// </summary>
		[ActionName(ApiConstants.UnrecognizedRouteAction)]
		[HttpDelete, HttpGet, HttpHead, HttpOptions, HttpPost, HttpPatch, HttpPut]
		public IHttpActionResult ProcessUnrecognizedRoute()
		{
			return NotFound();
		}
	}
