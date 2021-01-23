    /// <summary>
	/// Add a route constraint to detect version header or by query string
	/// </summary>
	public class RouteVersionHttpConstraint : IHttpRouteConstraint
	{
		public const string VersionHeaderName = "api-version";
		private const int DefaultVersion = 1;
		/// <summary>
		/// Add a route constraint to detect version header or by query string
		/// </summary>
		/// <param name="allowedVersion"></param>
		public RouteVersionHttpConstraint(int allowedVersion)
		{
			AllowedVersion = allowedVersion;
		}
		public int AllowedVersion
		{
			get;
			private set;
		}
		/// <summary>
		/// Perform the controller match
		/// </summary>
		/// <param name="request"></param>
		/// <param name="route"></param>
		/// <param name="parameterName"></param>
		/// <param name="values"></param>
		/// <param name="routeDirection"></param>
		/// <returns></returns>
		public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
		{
			if (routeDirection == HttpRouteDirection.UriResolution)
			{
				int version = GetVersionHeaderOrQuery(request) ?? DefaultVersion;
				if (version == AllowedVersion)
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Check the request header, and the query string to determine if a version number has been provided
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		private int? GetVersionHeaderOrQuery(HttpRequestMessage request)
		{
			string versionAsString;
			IEnumerable<string> headerValues;
			if (request.Headers.TryGetValues(VersionHeaderName, out headerValues) && headerValues.Count() == 1)
			{
				versionAsString = headerValues.First();
				int version;
				if (versionAsString != null && Int32.TryParse(versionAsString, out version))
				{
					return version;
				}
			}
			else
			{
				var query = System.Web.HttpUtility.ParseQueryString(request.RequestUri.Query);
				string versionStr = query[VersionHeaderName];
				int version = 0;
				int.TryParse(versionStr, out version);
				if (version > 0)
					return version;
			}
			return null;
		}
	}
