    [Produces("application/json")]
    [Route("api/Children")]
    public class ChildrenController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ChildrenController(ApplicationDbContext context)
        {
            _context = context;
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
                           $"{Request.Scheme}://{Request.Host}{Uri.RouteUrl("GetChildRoute", new { id = c.ChildId })}",
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
