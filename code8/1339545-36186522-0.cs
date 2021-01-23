	using System.Web.Http;
	using System.Web.OData;
	using System.Web.OData.Routing;
	[ODataRoutePrefix("Schools")]
	public sealed class SchoolODataController : ODataController
	{
		private DbContext _context; // your DbContext implementation, assume some DbSet<School> with the property name Schools
		public SchoolODataController(DbContext context)
		{
			_context = context;
		}
		[EnableQuery(MaxNodeCount = 200, MaxTop = 100, PageSize = 64 )]
		[ODataRoute]
		[HttpGet]
		public IHttpActionResult Get()
		{
			return Ok(_context.Schools);
		}
	}
