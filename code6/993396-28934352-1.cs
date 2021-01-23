    /// <summary>
	/// Versioning support for the WebAPI controllers
	/// </summary>
	public class RouteVersionAttribute : RouteFactoryAttribute
	{
		public int Version { get; private set; }
		public RouteVersionAttribute() : this(null, 1) 
		{ 
		}
		/// <summary>
		/// Specify a version for the WebAPI controller
		/// </summary>
		/// <param name="version"></param>
		public RouteVersionAttribute(int version) : this(null, version)
		{
		}
		public RouteVersionAttribute(string template, int version)
			: base(template)
		{
			Version = version;
		}
		public override IDictionary<string, object> Constraints
		{
			get
			{
				var constraints = new HttpRouteValueDictionary();
				constraints.Add("version", new RouteVersionHttpConstraint(Version));
				return constraints;
			}
		}
		public override IDictionary<string, object> Defaults
		{
			get
			{
				var defaults = new HttpRouteValueDictionary();
				defaults.Add("version", 1);
				return defaults;
			}
		}
	
	}
