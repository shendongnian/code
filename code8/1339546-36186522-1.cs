	using System.Web.Http;
	using System.Web.OData.Builder;
	using System.Web.OData.Extensions;
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// other code
			config.MapODataServiceRoute("odata", "odata", GetModel());
		}
		
		public static IEdmModel GetModel()
		{
			var builder = new ODataConventionModelBuilder();
			builder.EnableLowerCamelCase();
			var setOrders = builder.EntitySet<SchoolModel>("Schools").EntityType.HasKey(x => new { x.SchoolId });
			return builder.GetEdmModel();
		}
	}
	
