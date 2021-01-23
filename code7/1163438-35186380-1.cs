    [Produces("application/json")]
    [Route("api/Children")]
    public class ChildrenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUrlHelper _urlHelper;
        public ChildrenController(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _urlHelper = contextAccessor.HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
        }
        // GET: api/Children
        [HttpGet]
        public IEnumerable<Child> GetChild()
        {
            return _context.Child;
        }
        [HttpGet("uris")]
        public IEnumerable<Uri> GetChildUris()
        {
            return from c in _context.Child
                   select
                       new Uri(
                           $"{Request.Scheme}://{Request.Host}{_urlHelper.RouteUrl("GetChildRoute", new { id = c.ChildId })}",
                           UriKind.Absolute);
        }
        // GET: api/Children/5
        [HttpGet("{id}", Name = "GetChildRoute")]
        public IActionResult GetChild([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            Child child = _context.Child.Single(m => m.ChildId == id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return Ok(child);
        }
    }
