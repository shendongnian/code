    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http.Routing;
    
    namespace Boyd.Core.Filters
    {
    	/// <summary>
    	/// Here is a solution that will let you use the Web API 2 way of versioned routes (headers),
    	/// in addition to query parameter support (i.e.use a header called 'api-version' or 
    	/// a querystring parameter named '?api-version=XXX'.
    	/// <para>https://stackoverflow.com/a/28934352/3187389</para>
    	/// <para>https://stackoverflow.com/questions/25299889/customize-maphttpattributeroutes-for-web-api-versioning</para>
    	/// </summary>
    	public class RouteVersionHttpConstraint : IHttpRouteConstraint
    	{
    		public const string VersionHeaderName = "api-version";
    		private readonly int VersionDefault = 1;
    
    		/// <summary>
    		/// Add a route constraint to detect version header or by query string
    		/// </summary>
    		/// <param name="allowedVersion"></param>
    		public RouteVersionHttpConstraint(int allowedVersion, int versionDefault)
    		{
    			AllowedVersion = allowedVersion;
    			VersionDefault = versionDefault;
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
    				int version = GetVersionHeaderOrQuery(request) ?? VersionDefault;
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
    			if (request.Headers.TryGetValues(VersionHeaderName, out IEnumerable<string> headerValues) 
    				&& headerValues.Count() == 1)
    			{
    				versionAsString = headerValues.First();
    				if (versionAsString != null && Int32.TryParse(versionAsString, out int version))
    				{
    					return version;
    				}
    			}
    			else
    			{
    				var query = System.Web.HttpUtility.ParseQueryString(request.RequestUri.Query);
    				string versionStr = query[VersionHeaderName];
    				int.TryParse(versionStr, out int version);
    				if (version > 0)
    					return version;
    			}
    			return null;
    		}
    	}
    }
