    using System.Collections.Generic;
    using System.Web.Http.Routing;
    
    namespace YourNameSpace.Filters
    {
    	/// <summary>
    	/// Here is a solution that will let you use the Web API 2 way of versioned routes (headers),
    	/// in addition to query parameter support (i.e.use a header called 'api-version' or 
    	/// a querystring parameter named '?api-version=XXX'.
    	/// <para>https://stackoverflow.com/a/28934352/3187389</para>
    	/// <para>https://stackoverflow.com/questions/25299889/customize-maphttpattributeroutes-for-web-api-versioning</para>
    	/// </summary>
    	public class RouteVersionAttribute : RouteFactoryAttribute
    	{
    		public int Version { get; private set; }
    		public int VersionDefault { get; private set; }
    
    		public RouteVersionAttribute() : this(null, 1, true)
    		{
    		}
    
    		/// <summary>
    		/// Specify a version for the WebAPI controller or an action method
    		/// for example: [RouteVersion("Test", 1)] or [RouteVersion("Test", 1, true)]
    		/// </summary>
    		/// <param name="version"></param>
    		/// <param name="isDefault"></param>
    		public RouteVersionAttribute(int version, bool isDefault = false) : this(null, version, isDefault)
    		{
    		}
    
    		/// <summary>
    		/// Specify a version for the WebAPI controller or an action method
    		/// for example: [RouteVersion("Test", 1)] or [RouteVersion("Test", 1, true)]
    		/// </summary>
    		/// <param name="template"></param>
    		/// <param name="version"></param>
    		/// <param name="isDefault"></param>
    		public RouteVersionAttribute(string template, int version, bool isDefault = false)
    			: base(template)
    		{
    			Version = version;
    			if (isDefault)
    				VersionDefault = version;
    		}
    
    		public override IDictionary<string, object> Constraints
    		{
    			get
    			{
    				var constraints = new HttpRouteValueDictionary();
    				constraints.Add("version", new RouteVersionHttpConstraint(Version, VersionDefault));
    				return constraints;
    			}
    		}
    
    		public override IDictionary<string, object> Defaults
    		{
    			get
    			{
    				var defaults = new HttpRouteValueDictionary();
    				defaults.Add("version", VersionDefault);
    				return defaults;
    			}
    		}
    	}
    }
